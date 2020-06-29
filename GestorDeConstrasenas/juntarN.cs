using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GestorDeConstrasenas { 
    class juntarN : INotifyPropertyChanged
{
    
        private string nombre, apellido, nombre_completo;

        public string Nombre 
        { 
            get => nombre;
            set { nombre = value; OnPropertyChanged("Nombre_completo"); }
        }
        public string Apellido { get => apellido; set { apellido = value; OnPropertyChanged("Nombre_completo"); } }
        public string Nombre_completo { 
            get { 
                nombre_completo = nombre + " " + apellido;
                return nombre_completo;
                }  
        }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String property) 
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }

}

}


