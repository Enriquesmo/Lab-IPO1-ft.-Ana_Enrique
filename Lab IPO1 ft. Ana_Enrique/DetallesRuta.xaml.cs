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
    /// Lógica de interacción para DetallesRuta.xaml
    /// </summary>
    public partial class DetallesRuta : Window
    {
        Ruta rutaADevolver = new Ruta("","",null,"",0,0,0,null);
        public DetallesRuta(Ruta Ruta)
        {
            InitializeComponent();
            ComboBoxDificultad.Items.Add("Fácil");
            ComboBoxDificultad.Items.Add("Media");
            ComboBoxDificultad.Items.Add("Díficil");
            ComboBoxSeCome.Items.Add("Si");
            ComboBoxSeCome.Items.Add("No");
            ComboBoxFinalizada.Items.Add("Si");
            ComboBoxFinalizada.Items.Add("No");
            if (Ruta == null)
            {
                //btnModificar.IsEnabled = false; // cuidado
            }
            else
            {
                rutaADevolver = Ruta;
                //btnAnadirRuta.IsEnabled = false; // cuidado
                txbNombre.Text = Ruta.Nombre;
                txbProvincia.Text = Ruta.Provincia;
                ComboBoxDificultad.Text = Ruta.Dificultad;
                // DatePickerFechaYHora.Text = Ruta.FechayHora.ToString();     // Aun por terminar
                txbOrigen.Text = Ruta.Origen;
                txbLlegada.Text = Ruta.formaLlegada;
                txbDestino.Text = Ruta.Destino;
                txbVuelta.Text = Ruta.formaVuelta;
                txbDuracion.Text = Ruta.Duracion.ToString();
                txbMaxPartic.Text = Ruta.maxParticipantes.ToString();
                /*
                for(int i = 0; i < Ruta.material.Count; i++)
                {
                    txbMaterial.Text += Ruta.material;
                }
                
                for (int i = 0; i < Ruta.incidencias.Count; i++)
                {
                   ListBoxIncidencias.Items.Add(Ruta.incidencias[i]);
                }
                */
                if (Ruta.seCome == true)
                {
                    ComboBoxSeCome.Text = "Si";
                }else {
                    ComboBoxSeCome.Text = "No";
                }

                if (Ruta.Finalizada == true)
                {
                    ComboBoxFinalizada.Text = "Si";
                }
                else
                {
                    ComboBoxFinalizada.Text = "No";
                }
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            txbNombre.Text = "";
            txbProvincia.Text = "";
            ComboBoxDificultad.Text = "";
            DatePickerFechaYHora.Text = "";
            txbOrigen.Text = "";
            txbLlegada.Text = "";
            txbDestino.Text = "";
            txbVuelta.Text = "";
            txbMaterial.Text = "";
            ComboBoxSeCome.Text = "";
            ComboBoxFinalizada.Text = "";
            txbDuracion.Text = "";
            txbMaxPartic.Text = "";
            ComboBoxGuia.Text = "";
            txbDescripcion.Text = "";
        }
        private void AnadirMaterial_Click(object sender, RoutedEventArgs e) //terminado
        {
            ListBoxMaterial.Items.Add(txbMaterial.Text);
        }
        private void btnBorrarMaterial_Click(object sender, RoutedEventArgs e) // terminado
        {
            ListBoxMaterial.Items.Remove(ListBoxMaterial.SelectedItem);
        }
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            rutaADevolver.Nombre = introducirString(txbNombre.Text);
            if (rutaADevolver.Nombre.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre de la ruta.\n - La duración de la ruta.\n - El máximo número de participantes.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
            }
            rutaADevolver.Provincia = introducirString(txbProvincia.Text);
            rutaADevolver.Dificultad = introducirString(ComboBoxDificultad.Text);
            rutaADevolver.formaLlegada = introducirString(txbLlegada.Text);
            rutaADevolver.formaVuelta = introducirString(txbVuelta.Text);
            rutaADevolver.material = extraerElementosListBox(ListBoxMaterial);
            rutaADevolver.seCome = comprobarOpcion(ComboBoxSeCome.Text);
            // HAY QUE HACER QUE SE META EN LA RUTA EL GUIA ASIGNADO
            rutaADevolver.Descripcion = introducirString(txbDescripcion.Text);
            rutaADevolver.Origen = introducirString(txbOrigen.Text);
            rutaADevolver.Destino = introducirString(txbDestino.Text);
            // HAY QUE HACER QUE SE META EN LA RUTA LA FECHA ASIGNADA
            rutaADevolver.Finalizada = comprobarOpcion(ComboBoxFinalizada.Text);
            bool esNumeroDuracion = introducirNumero(txbDuracion, rutaADevolver.Duracion, "la duración");
            bool esNumeroMaxParticipantes = introducirNumero(txbMaxPartic, rutaADevolver.maxParticipantes, "el número máximo de participantes");
            if (esNumeroDuracion == true && esNumeroMaxParticipantes == true)
            {
                // Aqui hacer que se devuelva la ruta resultante para que se añada a la otra ventana
            }
        }
        /*Metodos auxiliares para devolver correctamente la ruta creada o modificada*/
        private bool introducirNumero(TextBox textbox, int receptor, string mensaje)
        {
            int aDevolver;
            bool esNumero = int.TryParse(textbox.Text, out aDevolver);
            if (esNumero == true)
            {
                receptor = aDevolver;
            }
            else
            {
                MessageBox.Show("Error al Introducir " + mensaje + ".\nDebe introducir un número.", "Error", MessageBoxButton.OK);
                esNumero = false;
            }
            return esNumero;
        }
        private string introducirString(string emisor)
        {
            string contenidoAMeter;
            if (emisor.Equals(null))
            {
                contenidoAMeter = "";
            }
            else
            {
                contenidoAMeter = emisor;
            }
            return contenidoAMeter;
        }
        private List<string> extraerElementosListBox(ListBox listbox)
        {
            List<string> listaADevolver = null;
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                string aux = (string)listbox.Items[i];
                listaADevolver.Add(aux);
            }
            return listaADevolver;
        }
        private bool comprobarOpcion(string opcion)
        {
            bool respuesta = false;
            if (opcion.Equals("Si"))
            {
                respuesta = true;
            }
            else // En caso de que no haya nada puesto, se supone que es un "no"
            {
                respuesta = false;
            }
            return respuesta;
        }
        /*Boton reservado para la Ventana Guias*/
        private void btnListaGuias_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
