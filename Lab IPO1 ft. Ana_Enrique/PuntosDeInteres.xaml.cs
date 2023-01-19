using Microsoft.Win32;
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

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para PuntosDeInteres.xaml
    /// </summary>
    public partial class PuntosDeInteres : Window
    {
        /************************************************************************************************/

        /*Inicializacion de la ventana PuntosDeInteres*/
        public int indi = 1;

        public PuntosDeInteres(Ruta ruta)
        {
            InitializeComponent();
            cbTipo.Items.Add("Mirador");
            cbTipo.Items.Add("Área de avistamiento de aves");
            cbTipo.Items.Add("Existencia de plantas autóctonas");
            cbTipo.Items.Add("Masa de agua");
            cbTipo.Items.Add("Margen de un río");
            cbTipo.Items.Add("Puentes");
            cbTipo.Items.Add("Pinturas rupestres");
            cbTipo.Items.Add("Edificación de interés histórico");
            foreach (PuntoDeInteres x in ruta.puntosInteres){
                ListaPuntos.Items.Add(x);
               
            }
            if (ruta.Finalizada)
            {
                btnBorrarP.IsEnabled = false;
                btnAnadirP.IsEnabled = false;
                btnModP.IsEnabled = false;
                btnAnadirImg.IsEnabled = false;
            }
            lblImagenes.Content = "0/0";
            btnDcha.IsEnabled = false;
            btnIzq.IsEnabled = false;  
            
        }

        private void ListaPuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListaPuntos.Items.Refresh();
            PuntoDeInteres puntosel = ListaPuntos.SelectedItem as PuntoDeInteres;
            if (puntosel != null)
            {
                txbDescripcion.Text = puntosel.Descripcion;
                txbNombreP.Text = puntosel.Nombre;
                var bitmap = new BitmapImage(puntosel.galeria.ElementAt(0));
                indi = 1;
                lblImagenes.Content = indi + "/" + puntosel.galeria.Count;
                Img.Source = bitmap;
                if (puntosel.galeria.Count > 1)
                {
                    btnDcha.IsEnabled=true;
                }
                
              
                foreach (String s in cbTipo.Items)
                {
                    if (puntosel.Tipo.Equals(s))
                    {
                        cbTipo.SelectedItem = s;
                    }
                }
            }
        }





        /************************************************************************************************/

        /*Botones de la propia pagina PuntosDeInteres*/
        private void btnAnadirP_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres nuevo = new PuntoDeInteres(txbNombreP.Text, txbDescripcion.Text);
            nuevo.Tipo = cbTipo.SelectedItem.ToString();
            ListaPuntos.Items.Add(nuevo);
        }

        private void btnBorrarP_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            ListaPuntos.Items.Remove(selecci);
            txbNombreP.Text= "";
            txbDescripcion.Text = "";
            cbTipo.SelectedIndex = -1;

        }

        private void btnModP_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            selecci.Nombre = txbNombreP.Text;
            selecci.Descripcion= txbDescripcion.Text;
            selecci.Tipo = cbTipo.SelectedItem.ToString();
        }

        private void btnAnadirImg_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres selecci= ListaPuntos.SelectedItem as PuntoDeInteres ;
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Relative));
                    selecci.galeria.Add(new Uri(abrirDialog.FileName, UriKind.Relative));
                    lblImagenes.Content = indi + "/" + selecci.galeria.Count;
                    btnDcha.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }

        }

        private void btnDcha_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            indi++;
            var bitmap = new BitmapImage(selecci.galeria.ElementAt(indi-1));
            Img.Source = bitmap;
            btnIzq.IsEnabled = true;
            
            lblImagenes.Content = indi + "/" + selecci.galeria.Count;
            if (indi == selecci.galeria.Count)
            {
                btnDcha.IsEnabled = false;
            }

        }

        private void btnIzq_Click(object sender, RoutedEventArgs e)
        {
            PuntoDeInteres selecci = ListaPuntos.SelectedItem as PuntoDeInteres;
            indi--;
            var bitmap = new BitmapImage(selecci.galeria.ElementAt(indi - 1));
            Img.Source = bitmap;
            btnDcha.IsEnabled=true;

            lblImagenes.Content = indi + "/" + selecci.galeria.Count;
            if (indi == 1)
            {
                btnIzq.IsEnabled = false;
            }
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" ·Para consultar los detalles de un Punto de Interés, seleccione uno de la lista de la izquierda.\n \n ·A su vez, para añadir un punto nuevo, rellene todos sus campos. \n\n ·Por ultimo, tenga en cuenta que si la ruta ha sido finalizada, no se podrán modificar sus Puntos de interés.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);

        }


        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/
        //???

    }
}
