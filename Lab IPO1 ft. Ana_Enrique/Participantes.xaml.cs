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
            ListaParticipantes.ItemsSource = lista;
            
        }

        /************************************************************************************************/

        /*Botones de la propia ventana Participantes*/

        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selec = ListaParticipantes.SelectedItem as Excursionista;
            txbNombreApp.Text = selec.Nombre + " "+ selec.Apellidos;
            txbEdad.Text = selec.Edad.ToString();
            txbTelef.Text= selec.Telefono.ToString();
            txbDni.Text = selec.DNI;
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí hay que introducir la ayuda que se facilitará al usuario para esta ventana.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/


    }
}
