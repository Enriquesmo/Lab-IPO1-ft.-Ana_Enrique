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
        

        public PuntosDeInteres(Ruta ruta)
        {
            InitializeComponent();
            foreach(PuntoDeInteres x in ruta.puntosInteres){
                ListaPuntos.Items.Add(x);
            }
            if (ruta.Finalizada)
            {
                btnBorrarP.IsEnabled = false;
                btnAnadirP.IsEnabled = false;
                btnModP.IsEnabled = false;
            }
            
        }

        private void ListaPuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PuntoDeInteres puntosel = ListaPuntos.SelectedItem as PuntoDeInteres;
            txbDescripcion.Text = puntosel.Descripcion;
            txbNombreP.Text = puntosel.Nombre;
            cbTipo.Items.Add("Mirador");
            cbTipo.Items.Add("Área de avistamiento de aves");
            cbTipo.Items.Add("Existencia de plantas autóctonas");
            cbTipo.Items.Add("Masa de agua");
            cbTipo.Items.Add("Margen de un río");
            cbTipo.Items.Add("Puentes");
            cbTipo.Items.Add("Pinturas rupestres");
            cbTipo.Items.Add("Edificación de interés histórico");
            foreach(String s in cbTipo.Items)
            {
                if (puntosel.Tipo.Equals(s))
                {
                    cbTipo.SelectedItem = s;
                }
            }
        }



        /************************************************************************************************/

        /*Botones de la propia pagina PuntosDeInteres*/


        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/


    }
}
