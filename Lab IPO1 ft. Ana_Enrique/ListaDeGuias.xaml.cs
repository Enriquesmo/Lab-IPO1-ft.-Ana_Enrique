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
    /// Lógica de interacción para ListaDeGuias.xaml
    /// </summary>
    public partial class ListaDeGuias : Window
    {
        /************************************************************************************************/

        /*Inicializacion de la ventana ListaDeGuias*/

        public ListaDeGuias(ObservableCollection<Guia> listadoGuias)
        {
            InitializeComponent();
            for(int i = 0; i < listadoGuias.Count; i++)
            {
                ListaParticipantes.Items.Add(listadoGuias[i]);
            }
        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeGuias*/
        private void ListaParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnX_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            Guia seleccionada = ListaParticipantes.SelectedItem as Guia;
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere borrar el guia?.", "Confirmación", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ListaParticipantes.Items.Remove(seleccionada);
            }
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ListBoxIdiomas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBorrarIdioma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnadirIdioma_Click(object sender, RoutedEventArgs e)
        {

        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void estadoBotones(bool estado) // Finalizado
        {
            btnAnadir.IsEnabled = estado;
            btnMod.IsEnabled = estado;
            btnBorrar.IsEnabled = estado;
        }


    }
}
