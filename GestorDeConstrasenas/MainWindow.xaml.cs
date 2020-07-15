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
using System.Data.SqlClient;//clases utilizada para bases de datos
using System.Data;//clases utilizada para bases de datos

namespace GestorDeConstrasenas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        SqlConnection miConexionServidor;
        string stringConexion = ConfigurationManager.ConnectionStrings["GestorDeConstrasenas.Properties.Settings.gestor_KM_BDConnectionString"].ConnectionString;
        
        public MainWindow()
        {
            InitializeComponent();

        }

        //////////////////////FUNCION PARA INGRESAR A LA PLATAFORMA///////////////////
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            int respuestaPA;
            miConexionServidor = new SqlConnection(stringConexion);



            if (!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(txtContrasena.Password))
            {
                using (miConexionServidor)//aqui usamos la conexion a la bd 
                {
                    miConexionServidor.Open();
                    //creamos un instancia de comandos mandamos el nombre del procedimiento y la conexion a la base de datos
                    SqlCommand cmd = new SqlCommand("PingresarUsuario", miConexionServidor);
                    //definimos que la instancia cmd es tipo procedimeinto almacenado
                    cmd.CommandType = CommandType.StoredProcedure;
                    //agregamos los parametros a la query
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Password);
                    cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteReader();

                    respuestaPA = Convert.ToInt32(cmd.Parameters["@respuesta"].Value);
                }

                if (respuestaPA == 1)
                {
                   
                    Vcontrasena ventana = new Vcontrasena(txtUsuario.Text);
                    ventana.Show();
                    this.Close();
                   
                }
                else
                {

                    MessageBox.Show("error en el usuario o campo");
                }
            }
            else
            {
                MessageBox.Show("campos vacios porfavor llene ambos campos");
            }
            miConexionServidor.Close();

        }
        //////////////////////FUNCION PARA REGISTRAR A LA PLATAFORMA///////////////////
        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            int respuestaPA;
            miConexionServidor = new SqlConnection(stringConexion);



            if (!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(txtContrasena.Password))
            {
                using (miConexionServidor)//aqui usamos la conexion a la bd 
                {
                    miConexionServidor.Open();
                    //creamos un instancia de comandos mandamos el nombre del procedimiento y la conexion a la base de datos
                    SqlCommand cmd = new SqlCommand("PcrearUsuario", miConexionServidor);
                    //definimos que la instancia cmd es tipo procedimeinto almacenado
                    cmd.CommandType = CommandType.StoredProcedure;
                    //agregamos los parametros a la query
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Password);
                    cmd.Parameters.Add("@IngresiExitoso", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteReader();

                    /*if (lectura.)
                    {
                        Vcontrasena ventana = new Vcontrasena();
                        ventana.Show();
                        this.Close();
                        MessageBox.Show("entrando");
                    }*/

                    respuestaPA = Convert.ToInt32(cmd.Parameters["@IngresiExitoso"].Value);
                }

                if (respuestaPA == 1) { 
                    Vcontrasena ventana = new Vcontrasena();
                ventana.Show();
                this.Close();
                MessageBox.Show("entrando");
                }
                else
                {

                    MessageBox.Show("error dentro de procedimiento almacenado");
                }
            }
            else {
                MessageBox.Show("campos vacios porfavor llene ambos campos");
            }
            miConexionServidor.Close();
        }
    }
}
