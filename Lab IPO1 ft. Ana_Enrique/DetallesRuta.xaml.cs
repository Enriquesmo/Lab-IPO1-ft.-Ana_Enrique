using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para DetallesRuta.xaml
    /// </summary>
    public partial class DetallesRuta : Window
    {
        Ruta rutaADevolver = new Ruta("","",null,"",0,1,0);
        ObservableCollection<Guia> listadoGuiasAux;

        /************************************************************************************************/

        /*Inicializacion de la ventana ListaDeRutas*/

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
                txbDuracion.Text = Ruta.Duracion.ToString();
                txbMaxPartic.Text = Ruta.maxParticipantes.ToString();
                ComboBoxDificultad.Text = Ruta.Dificultad;
                DatePickerFechaYHora.SelectedDate = Ruta.FechayHora;
                introducirBoolean(Ruta.seCome, ComboBoxSeCome);
                introducirBoolean(Ruta.Finalizada, ComboBoxFinalizada);
                introducirEnLaListBox(ListBoxMaterial, Ruta.material);
                if (Ruta.guia != null)
                {
                    ComboBoxGuia.Text = Ruta.guia.Nombre;
                }
                /*Este if se hace ya que solo si la ruta esta finalizada, entonces debemos mostrar las incidencias*/
                if (Ruta.Finalizada == true)
                {
                    introducirEnLaListBox(ListBoxIncidencias, Ruta.incidencias);
                }
            }
        }

        /************************************************************************************************/

        /*Botones de la propia pagina ListaDeRutas*/

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
        private void btnFinalizar_Click(object sender, RoutedEventArgs e) // Terminado CREO
        {
            OperacionCompletada = false;
            bool esNumeroDuracion = introducirNumero(txbDuracion, rutaADevolver.Duracion, "la duración");
            bool esNumeroMaxParticipantes = introducirNumero(txbMaxPartic, rutaADevolver.maxParticipantes, "el número máximo de participantes");
            String nombreAux = introducirString(txbNombre.Text);

            bool hayNombre = true;
            if (nombreAux.Equals(""))
            {
                MessageBox.Show("Debe introducir al menos\n - El nombre de la ruta.\n para Finalizar este proceso.", "Error", MessageBoxButton.OK);
                hayNombre = false;
            }
            else
            {
                if (esNumeroDuracion == true && esNumeroMaxParticipantes == true && hayNombre == true )
                {
                    System.Windows.MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres guardar los cambios?", "Confirmación", MessageBoxButton.OKCancel);
                    if(result == MessageBoxResult.OK){
                        rutaADevolver.Nombre = introducirString(txbNombre.Text);
                        rutaADevolver.Provincia = introducirString(txbProvincia.Text);
                        rutaADevolver.Dificultad = introducirString(ComboBoxDificultad.Text);
                        rutaADevolver.formaLlegada = introducirString(txbLlegada.Text);
                        rutaADevolver.formaVuelta = introducirString(txbVuelta.Text);
                        rutaADevolver.material = extraerElementosListBox(ListBoxMaterial);
                        rutaADevolver.seCome = comprobarOpcion(ComboBoxSeCome.Text);
                        rutaADevolver.Descripcion = introducirString(txbDescripcion.Text);
                        rutaADevolver.Origen = introducirString(txbOrigen.Text);
                        rutaADevolver.Destino = introducirString(txbDestino.Text);
                        rutaADevolver.FechayHora = seleccionarFecha();
                        rutaADevolver.Finalizada = comprobarOpcion(ComboBoxFinalizada.Text);
                        if (seleccionarGuia(ComboBoxGuia).Nombre != "NoExisteGuia")
                        {
                            rutaADevolver.guia = seleccionarGuia(ComboBoxGuia);
                        }
                        /*Fase final*/
                        Result = rutaADevolver;
                        OperacionCompletada = true;
                        MessageBox.Show("Todos los cambios han sido guardados.", "Exito", MessageBoxButton.OK);
                        Close();
                    }
                }
            }
        }
        private void btnAyuda_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("La ventana esta dividida en 2 partes:\n" +
                "IZQUIERDA:\n - Se muestran todos los atributos de una ruta.\n - Se pueden modificar todos, excepto las incidencias.\n - En el campo Materiales, encontramos 2 botones:\n    . Borrar Mat\n    . Añadir Mat\n   Al seleccionar un material de la lista de abajo, se cumple con lo que\n   dice el botón.\n - El botón LISTA GUIAS, muestra una ventana para modificarlos." +
                "\nDERECHA:\n - El botón LIMPIAR, limpia todos los campos.\n - El botón GUARDAR, tiene 2 funcionalidades:\n    . Si ha entrado para MODIFICAR una ruta\n         Se guardan los cambios aplicados.\n    . Si ha entrado para AÑADIR una ruta\n         Se añade la ruta creada a la anterior ventana.", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /**************************************************************/

        /*Metodos reservado para la correcta devolucion de la Ruta a la hora de Crear una nueva*/
        public Ruta Result { get; set; } // Terminado
        public bool OperacionCompletada { get; set; } // Terminado

        /**************************************************************/

        /************************************************************************************************/

        /*Botones Reservados para la creacion de las diferentes Ventanas*/

        /*Boton reservado para la Ventana Guias*/
        private void btnListaGuias_Click(object sender, RoutedEventArgs e)
        {
            ListaDeGuias ventanaListaDeGuias = new ListaDeGuias(listadoGuiasAux);
            /*Utilizamos ShowDialog ya que vamos esperar a que la otra ventana se cierre para luego despues actualizarla correctamente*/
            ventanaListaDeGuias.ShowDialog();
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/
        private bool introducirNumero(TextBox textbox, int receptor, string mensaje) // Terminado
        {
            int aDevolver;
            bool esNumero = false;
            if (textbox.Text != "")
            { /*Hemos puesto esta condicion para que si el espacio esta en blanco, tambien pueda crearse la ruta*/
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
                esNumero = true;
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
            Guia guiaADevolver = new Guia("NoExisteGuia", "", null, 0, "", 0);

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
        private void introducirEnLaListBox(ListBox listbox, List<string> listaAIntroducir) // Terminado
        {
            if (listaAIntroducir != null)
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
    }
}
