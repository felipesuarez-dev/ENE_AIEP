using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ENEAIEP
{
    public partial class ListaRequerimientosAdmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NK53N6H\SQLEXPRESS;Initial Catalog=BDRequerimientoENETest;Integrated Security=True");

        public ListaRequerimientosAdmin()
        {
            InitializeComponent();
          
        }

        private void mostrarRequerimientos()
        {
            try
            {
                //Validación campos vacios Listado Requerimientos (variables a filtrar)
                //De pasar la validación, continúa en el "else" lo que serían las opciones a tener al escoger en los combobox y checkbox

                if (string.IsNullOrEmpty(cmbTipoRequerimientoLista.Text))
                {
                    MessageBox.Show("Tipo Requerimiento: Seleccione una opción", "ESCOGER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(string.IsNullOrEmpty(cmbPrioridadLista.Text))
                {
                    MessageBox.Show("Prioridad: Seleccione una opción", "ESCOGER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (chbPendientes.Checked == false && chbResueltos.Checked == false)
                {
                    MessageBox.Show("Estado Requerimiento: Seleccione una opción entre 'Pendiente', 'Resuelto' o puede escoger ambas para ver todos los requerimientos", "ESCOGER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else  // continuación
                {
                    con.Open();

                    //Selección combobox + checkbox (Distintas opciones)
                    //ORDEN: Todos, Servidores, Sistemas, Base de Datos

                    // TipoRequerimiento: Todos Y prioridad: Todos (+pendiente, +resuelto y pendiente y resuelto)
                    if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd3 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente'", con);
                        cmd3.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & (chbResueltos.Checked == true & chbResueltos.Checked == true))
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Todos Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Pendiente'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if(cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Todos Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Media' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Media' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Todos Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Todos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Servidores Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Servidores Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Servidores Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Servidores Y prioridad: Todos (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Servidores" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Todos (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Sistemas" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Baja' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Baja' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Media' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Media' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Alta' AND estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Alta' AND estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                    // TipoRequerimiento: Servidores Y prioridad: Todos (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente'", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Resuelto'", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }
                    else if (cmbTipoRequerimientoLista.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadLista.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT idRequerimiento, tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, asignado_a, asignado_por, estado FROM Requerimiento WHERE estado = 'Pendiente' AND estado = 'Resuelto'", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLista.DataSource = dt;

                        dgvLista.Columns[0].HeaderText = "ID";
                        dgvLista.Columns[1].HeaderText = "Tipo de Requerimiento";
                        dgvLista.Columns[2].HeaderText = "Prioridad";
                        dgvLista.Columns[3].HeaderText = "Descripción";
                        dgvLista.Columns[4].HeaderText = "Días Plazo";
                        dgvLista.Columns[5].HeaderText = "Asignado A";
                        dgvLista.Columns[6].HeaderText = "Asignado Por";
                        dgvLista.Columns[7].HeaderText = "Estado";


                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN BUSQUEDA: "+ex.Message);
            }
        }

        private void btnEliminarDeLista_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvLista.SelectedRows)
            {
                con.Open();
                try
                {
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Requerimiento WHERE idRequerimiento =@Index", con);
                    cmd2.Parameters.AddWithValue("@Index", item.Cells["idRequerimiento"].Value);
                    int i = cmd2.ExecuteNonQuery();
                    con.Close();

                    if (i != 0)
                    {
                        dgvLista.Rows.RemoveAt(item.Index);
                        MessageBox.Show("Requerimiento eliminado exitósamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el requerimiento", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL no EJECUTADO", "ERROR SQL" + ex.Message);

                }
            }
        }

        

        private void btnBuscarEnLista_Click(object sender, EventArgs e)
        {
            mostrarRequerimientos();
        }

        private void marcarResuelto()
        {
            foreach (DataGridViewRow item in this.dgvLista.SelectedRows)
            {
                con.Open();
                try
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE Requerimiento set estado = @Resuelto WHERE idRequerimiento = @Index", con);
                    cmd2.Parameters.AddWithValue("@Resuelto", "Resuelto");
                    cmd2.Parameters.AddWithValue("@Index", item.Cells["idRequerimiento"].Value);
                    int i = cmd2.ExecuteNonQuery();
                    

                    if (i != 0)
                    {
                        dgvLista.Rows.RemoveAt(item.Index);
                        MessageBox.Show("Requerimiento marcado como Resuelto", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido marcar el Requerimiento como Resuelto :(", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL no EJECUTADO", "ERROR SQL" + ex.Message);

                }
                con.Close();
            }

        }

        private void btnMarcarResuelto_Click(object sender, EventArgs e)
        {
            marcarResuelto();
        }
    }
}
