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

namespace ENEAIEP
{
    public partial class ListaRequerimientosEmpleado : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NK53N6H\SQLEXPRESS;Initial Catalog=BDRequerimientoENETest;Integrated Security=True");

        public ListaRequerimientosEmpleado()
        {
            InitializeComponent();
                        
        }

        private void btnBuscarEnLista_Click(object sender, EventArgs e)
        {
            mostrarRequerimiento();
        }

        private void cmbTipoRequerimientoListaE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEliminarDeLista_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvListaE.SelectedRows)
            {
                con.Open();
                try
                {
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Requerimiento WHERE tipoRequerimiento =@Index", con);
                    cmd2.Parameters.AddWithValue("@Index", item.Cells["tipoRequerimiento"].Value);
                    int i = cmd2.ExecuteNonQuery();
                    con.Close();

                    if (i != 0)
                    {
                        dgvListaE.Rows.RemoveAt(item.Index);
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

        public void mostrarRequerimiento()
        {
            try
            {
                //Validación campos vacios Listado Requerimientos (variables a filtrar)
                //De pasar la validación, continúa en el "else" lo que serían las opciones a tener al escoger en los combobox y checkbox

                if (string.IsNullOrEmpty(cmbTipoRequerimientoListaE.Text))
                {
                    MessageBox.Show("Tipo Requerimiento: Seleccione una opción", "ESCOGER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrEmpty(cmbPrioridadListaE.Text))
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
                    if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Todos" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd3 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE estado = 'Pendiente' AND (asignado_a = '"+txtUsuAct.Text+ "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd3.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Todos" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Todos Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto'AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Todos Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Media' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Media' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM WHERE prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Todos Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Todos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Servidores Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Servidores Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Servidores Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Servidores" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Servidores' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Sistemas Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Sistemas" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Sistemas' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Baja (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Baja' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base Datos' AND prioridad = 'Baja' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Baja" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Baja' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Media (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Media' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base Datos' AND prioridad = 'Media' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Media" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Media' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                    // TipoRequerimiento: Base de Datos Y prioridad: Alta (+pendiente, +resuelto y pendiente y resuelto)
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbPendientes.Checked == true)
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Alta' AND estado = 'Pendiente' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd5.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd6 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base Datos' AND prioridad = 'Alta' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd6.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd6);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }
                    else if (cmbTipoRequerimientoListaE.SelectedItem.ToString() == "Base de Datos" & cmbPrioridadListaE.SelectedItem.ToString() == "Alta" & chbResueltos.Checked == true & chbResueltos.Checked == true)
                    {
                        SqlCommand cmd4 = new SqlCommand("SELECT tipoRequerimiento, prioridad, descripcionRequerimiento, diasPlazo, estado FROM Requerimiento WHERE tipoRequerimiento = 'Base de Datos' AND prioridad = 'Alta' AND estado = 'Pendiente' AND estado = 'Resuelto' AND (asignado_a = '" + txtUsuAct.Text + "' OR asignado_por = '" + txtUsuAct.Text + "')", con);
                        cmd4.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd4);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListaE.DataSource = dt;

                        dgvListaE.Columns[0].HeaderText = "Tipo de Requerimiento";
                        dgvListaE.Columns[1].HeaderText = "Prioridad";
                        dgvListaE.Columns[2].HeaderText = "Descripción";
                        dgvListaE.Columns[3].HeaderText = "Días Plazo";
                        dgvListaE.Columns[4].HeaderText = "Estado";

                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN BUSQUEDA: " + ex.Message);
            }
        }

        private void btnMarcarResuelto_Click(object sender, EventArgs e)
        {
            marcarResuelto();
        }

        private void marcarResuelto()
        {
            foreach (DataGridViewRow item in this.dgvListaE.SelectedRows)
            {
                con.Open();
                try
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE Requerimiento set estado = @Resuelto WHERE tipoRequerimiento =@Index", con);
                    cmd2.Parameters.AddWithValue("@Resuelto", "Resuelto");
                    cmd2.Parameters.AddWithValue("@Index", item.Cells["tipoRequerimiento"].Value);
                    int i = cmd2.ExecuteNonQuery();
                    con.Close();

                    if (i != 0)
                    {
                        dgvListaE.Rows.RemoveAt(item.Index);
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
            }
        }
    }
}
