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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace GestorDeConstrasenas
{
    /// <summary>
    /// Interaction logic for Practicas.xaml
    /// </summary>
    public partial class Practicas : Window
    {
        juntarN persona;
        SqlConnection miConexionSql;




        public Practicas()
        {
            InitializeComponent();
            String miConexion = ConfigurationManager.ConnectionStrings["GestorDeConstrasenas.Properties.Settings.gestor_KM_BDConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(miConexion);





            persona = new juntarN() { Nombre = "kenny", Apellido = "molina" };



            this.DataContext = persona;

            List<Pobladores> listPob = new List<Pobladores>();

            listPob.Add(new Pobladores() { Nombre = "kenny", Nombre2 = "jared", Apellido = "molina", Apellido2 = "murillo" });
            listPob.Add(new Pobladores() { Nombre = "kenny1", Nombre2 = "jared1", Apellido = "molina1", Apellido2 = "murillo1" });
            listPob.Add(new Pobladores() { Nombre = "kenny2", Nombre2 = "jared2", Apellido = "molina2", Apellido2 = "murillo2" });
            listPob.Add(new Pobladores() { Nombre = "kenny3", Nombre2 = "jared3", Apellido = "molina3", Apellido2 = "murillo3" });

            listaPersona.ItemsSource = listPob;
            CBpersonas.ItemsSource = listPob;

            mostrar();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show((listaPersona.SelectedItem as Pobladores).Nombre + " " + (listaPersona.SelectedItem as Pobladores).Apellido);

        }
        //------------------------aqui empieza la funcion para mostrar la consulta   
        private void mostrar()
        {
            string consulta = "SELECT idUsuario,nombreUsuario FROM usuarios ";

            SqlDataAdapter miAdapSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdapSql)
            {
                DataTable usTabla = new DataTable();

                miAdapSql.Fill(usTabla);

                listaBD.DisplayMemberPath = "nombreUsuario";
                listaBD.SelectedValuePath = "idUsuario";
                listaBD.ItemsSource = usTabla.DefaultView;


                CBpersonas.DisplayMemberPath = "nombreUsuario";
                CBpersonas.SelectedValuePath = "idUsuario";
                CBpersonas.ItemsSource = usTabla.DefaultView;
            }
        }

        private void CBpersonas_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(CBpersonas.SelectedValue));
        }

        private void listaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //------------------------aqui termina la funcion para mostrar la consulta   


        //PRACTICANDO CODIGOS PAGINA OFICIAL MICROSOFT
        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            tb.Text = "   You selected " + lbi.Content.ToString() + ".";
        }

    }


    //----------------------aqui termina y empieza la clase 





    public class Pobladores
    {
        string nombre, nombre2;
        string apellido, apellido2;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Nombre2 { get => nombre2; set => nombre2 = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
    }









    

}
