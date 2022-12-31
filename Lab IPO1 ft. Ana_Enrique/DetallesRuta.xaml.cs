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
    /// Lógica de interacción para DetallesRuta.xaml
    /// </summary>
    public partial class DetallesRuta : Window
    {
        Ruta rutaADevolver = new Ruta("","",null,"",0,1,0,null);
        ObservableCollection<Guia> listadoGuiasAux;
        public DetallesRuta(Ruta Ruta, ObservableCollection<Guia> listadoGuias)
        {
            InitializeComponent();
            listadoGuiasAux= listadoGuias;
            ComboBoxDificultad.Items.Add("Facil");
            ComboBoxDificultad.Items.Add("Media");
            ComboBoxDificultad.Items.Add("Dificil");
            ComboBoxSeCome.Items.Add("Si");
            ComboBoxSeCome.Items.Add("No");
            ComboBoxFinalizada.Items.Add("Si");
            ComboBoxFinalizada.Items.Add("No");
            for (int i = 0; i < listadoGuias.Count; i++)
            {
                ComboBoxGuia.Items.Add(listadoGuias[i].Nombre);
            }
            if (Ruta != null)
            {
                rutaADevolver = Ruta;
                txbNombre.Text = Ruta.Nombre;
                txbProvincia.Text = Ruta.Provincia;
                txbOrigen.Text = Ruta.Origen;
                txbLlegada.Text = Ruta.formaLlegada;
                txbDestino.Text = Ruta.Destino;
                txbVuelta.Text = Ruta.formaVuelta;
                txbDescripcion.Text = Ruta.Descripcion;
                ComboBoxGuia.Text = Ruta.guia.Nombre;
                txbDuracion.Text = Ruta.Duracion.ToString();
                txbMaxPartic.Text = Ruta.maxParticipantes.ToString();
                ComboBoxDificultad.Text = Ruta.Dificultad;
                DatePickerFechaYHora.SelectedDate = Ruta.FechayHora;
                introducirBoolean(Ruta.seCome, ComboBoxSeCome);
                introducirBoolean(Ruta.Finalizada, ComboBoxFinalizada);
                introducirEnLaListBox(ListBoxMaterial, Ruta.material);
                /*Este if se hace ya que solo si la ruta esta finalizada, entonces debemos mostrar las incidencias*/
                if (Ruta.Finalizada == true)
                {
                    introducirEnLaListBox(ListBoxIncidencias, Ruta.incidencias);
                }
            }
        }
        /*Metodos auxiliares para realizar la carga de datos en al ventana*/
        private void introducirEnLaListBox(ListBox listbox, List<string> listaAIntroducir) // Terminado
        {
            if (listaAIntroducir.Count > 0)
            {
                for (int i = 0; i < listaAIntroducir.Count; i++)
                {
                    listbox.Items.Add(listaAIntroducir[i]);
                }
            }
        }
        private void introducirBoolean(bool emisor, ComboBox receptor) // Terminado
        {
            if (emisor == true)
            {
                receptor.Text = "Si";
            }
            else
            {
                receptor.Text = "No";
            }
        }
        /*Funcionalidades programadas a los botones encontrados en esta ventana*/
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
            ListBoxIncidencias.Items.Clear();
            ListBoxMaterial.Items.Clear();
        }
        private void AnadirMaterial_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListBoxMaterial.Items.Add(txbMaterial.Text);
        }
        private void btnBorrarMaterial_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ListBoxMaterial.Items.Remove(ListBoxMaterial.SelectedItem);
        }
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            rutaADevolver.Nombre = introducirString(txbNombre.Text);
            bool hayNombre = true;
            if (rutaADevolver.Nombre.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre de la ruta.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
                hayNombre = false;
            }
            rutaADevolver.Provincia = introducirString(txbProvincia.Text);
            rutaADevolver.Dificultad = introducirString(ComboBoxDificultad.Text);
            rutaADevolver.formaLlegada = introducirString(txbLlegada.Text);
            rutaADevolver.formaVuelta = introducirString(txbVuelta.Text);
            rutaADevolver.material = extraerElementosListBox(ListBoxMaterial);
            rutaADevolver.seCome = comprobarOpcion(ComboBoxSeCome.Text);
            rutaADevolver.Descripcion = introducirString(txbDescripcion.Text);
            rutaADevolver.Origen = introducirString(txbOrigen.Text);
            rutaADevolver.Destino = introducirString(txbDestino.Text);
            rutaADevolver.FechayHora = seleccionarFecha(); // no estoy seguro
            rutaADevolver.Finalizada = comprobarOpcion(ComboBoxFinalizada.Text);
            bool esNumeroDuracion = introducirNumero(txbDuracion, rutaADevolver.Duracion, "la duración");
            bool esNumeroMaxParticipantes = introducirNumero(txbMaxPartic, rutaADevolver.maxParticipantes, "el número máximo de participantes");
            if (seleccionarGuia(ComboBoxGuia).Nombre != "NoExisteGuia")
            {
                rutaADevolver.guia = seleccionarGuia(ComboBoxGuia);
            }
            if (esNumeroDuracion == true && esNumeroMaxParticipantes == true && hayNombre == true)
            {
                Result = rutaADevolver;
                MessageBox.Show("Todos los cambios han sido guardados.", "Exito", MessageBoxButton.OK);
            }
        }
        /*Metodos auxiliares de la funcionalidad de devolver la ruta en el metodo llamado "btnFinalizar_Click"*/
        private bool introducirNumero(TextBox textbox, int receptor, string mensaje) // Terminado
        {
            int aDevolver;
            bool esNumero = false;
            if(textbox.Text != ""){ /*Hemos puesto esta condicion para que si el espacio esta en blanco, tambien pueda crearse la ruta*/
                esNumero = int.TryParse(textbox.Text, out aDevolver);
                if (esNumero == true)
                {
                    receptor = aDevolver;
                }
                else
                {
                    MessageBox.Show("Error al Introducir " + mensaje + ".\nDebe introducir un número.", "Error", MessageBoxButton.OK);
                    esNumero = false;
                }
            }
            else
            {
                esNumero= true;
            }
            return esNumero;
        }
        private string introducirString(string emisor) // Terminado
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
        private List<string> extraerElementosListBox(ListBox listbox) // Terminado
        {
            List<string> listaADevolver = new List<string> { };
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                string aux = (string)listbox.Items[i];
                listaADevolver.Add(aux);
            }
            return listaADevolver;
        }
        private bool comprobarOpcion(string opcion) // Terminado
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
        private Guia seleccionarGuia(ComboBox comboBox) // Terminado
        {
            Guia guiaADevolver =  new Guia("NoExisteGuia", "", null, 0, "", 0);

            if (comboBox.SelectedIndex != -1)
            {
                guiaADevolver = listadoGuiasAux[comboBox.SelectedIndex];
            }
            
            return guiaADevolver;
        }
        private DateTime seleccionarFecha() // Terminado
        {
            DateTime fecha = DateTime.Now;
            if (DatePickerFechaYHora.SelectedDate != null)
            {
                fecha = (DateTime)DatePickerFechaYHora.SelectedDate;
            }
            return fecha;
        }
        public Ruta Result { get; set; }
        /*Boton reservado para la Ventana Guias*/
        private void btnListaGuias_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
