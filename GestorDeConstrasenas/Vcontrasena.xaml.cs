using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorDeConstrasenas
{
    /// <summary>
    /// Interaction logic for Vcontrasena.xaml
    /// </summary>
    public partial class Vcontrasena : Window
    {
        
        SqlConnection miConexionSql;
        String usuarioIngresado;
       
        public Vcontrasena()
        {
            InitializeComponent();
            conexionBD objConexionBD = new conexionBD();
            miConexionSql =objConexionBD.miConexionSql ;
            mostrarContrasena();

           
            
        }
        public Vcontrasena(String usuarioIngresado)
        {
            InitializeComponent();
            this.usuarioIngresado = usuarioIngresado;
            LmostrarUsuario.Content +=usuarioIngresado;
            conexionBD objConexionBD = new conexionBD();
            miConexionSql = objConexionBD.miConexionSql;
            mostrarContrasena();

        }

        private void FmostrarContrasena() {
            MessageBox.Show( LBmostrarContrasena.SelectedItems.ToString());
        
        }

        private void mostrarContrasena()
        {
            string consulta = "select idContrasena,concat(nombrePlataforma,' ',correo) as info from contrasena where idUsuario=13";

            SqlDataAdapter miAdapSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdapSql)
            {
                DataTable usTabla = new DataTable();

                miAdapSql.Fill(usTabla);

                LBmostrarContrasena.DisplayMemberPath = "info";
                LBmostrarContrasena.SelectedValuePath = "idContrasena";
                LBmostrarContrasena.ItemsSource = usTabla.DefaultView;

            }
        }
    }
}
