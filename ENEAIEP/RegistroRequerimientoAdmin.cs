﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ENEAIEP
{
    public partial class RegistroRequerimientoAdmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NK53N6H\SQLEXPRESS;Initial Catalog=BDRequerimientoENETest;Integrated Security=True");

        public RegistroRequerimientoAdmin(string nombre, string apellido)
        {
            InitializeComponent();
            txtAsignadoPor.Visible = false;
            txtEstado.Visible = false;
            txtEstado.Text = "Pendiente";
            txtAsignadoPor.Text = nombre + " " + apellido;
            lblMensajeAdmin.Text = "Bienvenido " + nombre;
            cargarEmpleados();
            cargarTipoRequerimientos();
            cargarPrioridad();
        }

        public void cargarEmpleados()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select nombre, apellido from Usuario where tipoUsuario = 'Empleado'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbAsignado.Items.Add(dr[0].ToString()+" "+dr[1].ToString());
            }
            con.Close();
        }

        //Método para cargar los tipos de requerimientos en el combobox desde la base de datos
        public void cargarTipoRequerimientos()
        {
            con.Open();
            SqlCommand comando = new SqlCommand("select distinct(tipoRequerimiento) from Requerimiento", con);
            SqlDataReader dr8 = comando.ExecuteReader();
            while (dr8.Read())
            {
                cmbTipoRequerimiento.Items.Add(dr8[0].ToString());

            }
            con.Close();
        }

        //Método para cargar en el combobox la prioridad desde la base de datos
        public void cargarPrioridad()
        {
            con.Open();
            SqlCommand coma = new SqlCommand("select distinct(prioridad) from Requerimiento", con);
            SqlDataReader dtrd = coma.ExecuteReader();
            while (dtrd.Read())
            {
                cmbPrioridad.Items.Add(dtrd[0].ToString());
            }
            con.Close();
        }

        private void btnLimpiarCamposRegistro_Click(object sender, EventArgs e)
        {
            this.cmbTipoRequerimiento.SelectedItem = null;
            this.cmbAsignado.SelectedItem = null;
            txtDescripcionRequerimiento.Clear();
            this.cmbPrioridad.SelectedItem = null;
        }

        private void btnIrListaRequerimientos_Click(object sender, EventArgs e)
        {
            ListaRequerimientosAdmin lra = new ListaRequerimientosAdmin();
            lra.Show();
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            //Validación de Campos del Registro Requerimiento
            if (string.IsNullOrEmpty(cmbTipoRequerimiento.Text))
            {
                MessageBox.Show("Debes ingresar un tipo de requerimiento");
            }
            else if (string.IsNullOrEmpty(cmbAsignado.Text))
            {
                MessageBox.Show("Debes ingresar un Empleado");
            }
            else if (string.IsNullOrEmpty(txtDescripcionRequerimiento.Text))
            {
                MessageBox.Show("Debes ingresar una descripción");
            }
            else if (string.IsNullOrEmpty(cmbPrioridad.Text))
            {
                MessageBox.Show("Debes asignar una prioridad");
            }
            else
            {

                //Capturar el número de días de realización del requerimiento según la prioridad, para añadirlo como dato a la base de datos
                string ndias = cmbPrioridad.Text;
                if(cmbPrioridad.SelectedItem.ToString() == "Alta")
                {
                    ndias = "3 Días";
                    txtDiasPlazo.Text = ndias;
                }

                else if (cmbPrioridad.SelectedItem.ToString() == "Media")
                {
                    ndias = "4 Días";
                    txtDiasPlazo.Text = ndias;
                }

                else if (cmbPrioridad.SelectedItem.ToString() == "Baja")
                {
                    ndias = "5 Días";
                    txtDiasPlazo.Text = ndias;
                }

                //Inicio de inserción de los campos llenados en la base de datos
                con.Open();
                string cadena = "INSERT INTO Requerimiento ([tipoRequerimiento], [asignado_a], [asignado_por], [descripcionRequerimiento], [prioridad], [estado], [diasPlazo]) VALUES ('" + cmbTipoRequerimiento.Text + "','" + cmbAsignado.Text + "','" + txtAsignadoPor.Text + "','" + txtDescripcionRequerimiento.Text + "','" + cmbPrioridad.Text + "','" + txtEstado.Text + "', '"+txtDiasPlazo.Text+"')";
                SqlCommand cmd = new SqlCommand(cadena, con);
                cmd.ExecuteNonQuery();

                //Mensaje de confirmación del registro, mostrando el número de días para resolver el Requerimiento
                if (cmbPrioridad.SelectedItem.ToString() == "Alta")
                {
                    MessageBox.Show("El requerimiento fue ingresado, el plazo para resolverlo es de 3 días");
                }

                else if (cmbPrioridad.SelectedItem.ToString() == "Media")
                {
                    MessageBox.Show("El requerimiento fue ingresado, el plazo para resolverlo es de 4 días");
                }
                else if (cmbPrioridad.SelectedItem.ToString() == "Baja")
                {
                    MessageBox.Show("El requerimiento fue ingresado, el plazo para resolverlo es de 5 días");
                }
                con.Close();
            }

        }
    }
}