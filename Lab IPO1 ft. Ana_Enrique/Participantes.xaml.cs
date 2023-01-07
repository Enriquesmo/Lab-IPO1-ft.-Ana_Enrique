using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para Participantes.xaml
    /// </summary>
    public partial class Participantes : Window
    {
        /************************************************************************************************/
        ObservableCollection<Excursionista> lista = new ObservableCollection<Excursionista>();
        Excursionista selec;
        /*Inicializacion de la ventana Participantes*/

        public Participantes(Ruta ruta)
        {
            InitializeComponent();
            lista = ruta.participantes;
            foreach (Excursionista ex in lista)
            {
                ListaParticipantes.Items.Add(ex);
            }
            
        }

        /************************************************************************************************/

        /*Botones de la propia ventana Participantes*/

        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selec = ListaParticipantes.SelectedItem as Excursionista;
            txbNombre.Text = selec.Nombre;
            txbApp.Text = selec.Apellidos;
            txbEdad.Text = selec.Edad.ToString();
            txbTelef.Text= selec.Telefono.ToString();
            txbDni.Text = selec.DNI;
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí hay que introducir la ayuda que se facilitará al usuario para esta ventana.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
           
            selec = ListaParticipantes.SelectedItem as Excursionista;
            ListaParticipantes.Items.Remove(selec);
           
        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            lista.Add(nuevo);
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            selec = ListaParticipantes.SelectedItem as Excursionista;
            ListaParticipantes.Items.Remove(selec);
            lista.Remove(selec);
            lista.Add(nuevo);
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/


    }
}
