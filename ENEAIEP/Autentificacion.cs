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
    public partial class Autentificacion : Form
    {
        public Autentificacion()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NK53N6H\SQLEXPRESS;Initial Catalog=BDRequerimientoENETest;Integrated Security=True");

        //Método para validar tipo de usuario
        public void Logear(string usuario, string contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT nombre, apellido, tipoUsuario FROM Usuario where usuario=@usuario AND password=@pass", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][2].ToString() == "Admin")
                    {
                        RegistroRequerimientoAdmin rra = new RegistroRequerimientoAdmin(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                        rra.Show();
                    }
                    else if (dt.Rows[0][2].ToString() == "Empleado")
                    {
                        RegistroRequerimientoEmpleado rre = new RegistroRequerimientoEmpleado(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                        rre.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Inválido");
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }
        }
            
        
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            Logear(this.txtUsuario.Text, txtPass.Text);
        }

        private void btnSalirAut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}