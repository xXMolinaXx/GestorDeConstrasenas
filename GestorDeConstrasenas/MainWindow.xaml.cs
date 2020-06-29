using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;

namespace GestorDeConstrasenas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection miConexionSql;
        String Vusuario, Vcontrasena;
        string miConexion = ConfigurationManager.ConnectionStrings["GestorDeConstrasenas.Properties.Settings.gestor_KM_BDConnectionString"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
            
             miConexionSql = new SqlConnection(miConexion);
            miConexionSql.Open();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string queryString =
        "select usuarios,contrasena from usuarios;";
            using (SqlConnection connection = new SqlConnection(
                       miConexion))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader[0], reader[1]));

                        if (txtUsuario.Text.Equals(reader[0]) /*&& txtContrasena.Password.Equals(reader[1])*/)
                        {

                            Vcontrasena venContr = new Vcontrasena();
                            venContr.Show();
                            this.Close();

                        }
                        
                           
                        
                    }
                }
            }
            MessageBox.Show("datos incorrectos");
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "execute PcrearUsuario '"+ txtUsuario.Text + " ','"+ txtContrasena.Password.ToString() + "' ";
            MessageBox.Show(txtUsuario.Text + txtContrasena.Password.ToString());

            SqlCommand cmd = new SqlCommand(consulta, miConexionSql);
            cmd.ExecuteNonQuery();
            miConexionSql.Close();
            /*Practicas ventana = new Practicas();
            ventana.Show();
            this.Close();*/
        }
    }
}
