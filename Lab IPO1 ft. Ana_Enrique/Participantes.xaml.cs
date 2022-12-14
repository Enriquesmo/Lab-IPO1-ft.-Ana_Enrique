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
            ListaParticipantes.Items.Refresh();
            selec = ListaParticipantes.SelectedItem as Excursionista;
            if (selec != null)
            {
                txbNombre.Text = selec.Nombre;
                txbApp.Text = selec.Apellidos;
                txbEdad.Text = selec.Edad.ToString();
                txbTelef.Text = selec.Telefono.ToString();
                txbDni.Text = selec.DNI;
            }
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí hay que introducir la ayuda que se facilitará al usuario para esta ventana.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
           
            ListaParticipantes.Items.Remove(ListaParticipantes.SelectedItem);
            txbNombre.Text = "";
            txbApp.Text = "";
            txbEdad.Text = "";
            txbTelef.Text = "";
            txbDni.Text = "";



        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            ListaParticipantes.Items.Add(nuevo);
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Excursionista nuevo = new Excursionista(txbNombre.Text, txbApp.Text, int.Parse(txbEdad.Text), int.Parse(txbTelef.Text), txbDni.Text);
            selec = ListaParticipantes.SelectedItem as Excursionista;
            selec.Edad = int.Parse(txbEdad.Text);
            selec.DNI = txbDni.Text;
            selec.Apellidos= txbApp.Text;
            selec.Nombre= txbNombre.Text;
            selec.Telefono = int.Parse(txbTelef.Text);
            MessageBox.Show("Participante modificado");
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/


    }
}
