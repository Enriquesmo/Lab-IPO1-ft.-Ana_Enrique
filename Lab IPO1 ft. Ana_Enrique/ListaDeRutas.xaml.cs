using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

// TERMINADA

namespace Lab_IPO1_ft.Ana_Enrique
{
    /// <summary>
    /// Lógica de interacción para ListaDeRutas.xaml
    /// </summary>
    public partial class ListaDeRutas : Window
    {
        ObservableCollection<Excursionista> listadoParticipantes;
        ObservableCollection<Guia> listadoGuias;
        ObservableCollection<Ruta> original = new ObservableCollection<Ruta>();

        /************************************************************************************************/

        /*Inicializacion de la ventana ListaDeRutas*/

        public ListaDeRutas() // Terminado
        {
            InitializeComponent();
            /*Inicialización de los listados de rutas, participantes y guias*/
            listadoParticipantes= new ObservableCollection<Excursionista>();
            listadoGuias= new ObservableCollection<Guia>();
            mapa.Visibility = Visibility.Hidden;
            estadoBotones(false);

            /*Creación de Guias de ejemplo*/
            Guia guia1 = new Guia("Antonio", "Gutierrez Moraleda", null, 789456123, "antogutimora@gmail.com", 8);
            guia1.Foto= new Uri("/EjemploHombre.jpeg", UriKind.Relative);
            guia1.Idiomas.Add("Ingles");
            guia1.Idiomas.Add("Español");
            guia1.Rutas.Add("Camino de santiago");
            guia1.Rutas.Add("Ruta A");
            listadoGuias.Add(guia1);

            Guia guia2 = new Guia("Manoli", "Garcia Sanchez", null, 123456789, "manoligs@gmail.com", 10);
            guia2.Foto= new Uri("/Foto Persona1.jpg", UriKind.Relative);
            guia2.Idiomas.Add("Español");
            guia2.Idiomas.Add("Aleman");
            guia2.Rutas.Add("Ruta de la mancha");
            guia2.Rutas.Add("Ruta B");
            listadoGuias.Add(guia2);

            /*Creación de Excursionistas de ejemplo*/
            Excursionista part1 = new Excursionista("Marta", "Sanchez Ruiz", 23, 345678912, "70747431X");
            part1.Foto= new Uri("/Foto Persona1.jpg", UriKind.Relative);
            Excursionista part2 = new Excursionista("Marcos", "Diaz Sanchez", 27, 456789123, "52021073J");
            part2.Foto= new Uri("/EjemploHombre.jpeg", UriKind.Relative);
            Excursionista part3 = new Excursionista("Antonio", "Rodriguez Gomez", 37, 669733434, "21773636M");
            part3.Foto = new Uri("/EjemploHombre.jpeg", UriKind.Relative);

           

            /*Creacion de Puntos de interes de ejemplo*/
            PuntoDeInteres punto1 = new PuntoDeInteres("Lagunas de Ruidera", "Lagunas de ruidera, te puedes bañar", "Masa de agua");
            PuntoDeInteres punto2 = new PuntoDeInteres("Tablas de Daimiel", "Puedes ver pajaros","Área de avistamiento de aves" );
            PuntoDeInteres punto3 = new PuntoDeInteres("Ermita de Santa Lucía","Virgen de Santa Lucía", "Edificación de interés histórico");
            PuntoDeInteres punto4 = new PuntoDeInteres("El Molino de Fuente El Fresno", "Molino Casi-Quemado", "Mirador");
            punto1.galeria.Add(new Uri("/LagunasRuidera1.jpeg", UriKind.Relative));
            punto1.galeria.Add(new Uri("/LagunasRuidera2.jpeg", UriKind.Relative));
            punto2.galeria.Add(new Uri("/TablasDaimiel.jpeg", UriKind.Relative));
            punto3.galeria.Add(new Uri("/ErmitaSL.jpeg", UriKind.Relative));
            punto4.galeria.Add(new Uri("/MolinoFuente.jpg", UriKind.Relative));

            /*Creacion de Rutas de ejemplo*/
            Ruta ruta1 = new Ruta("Ruta A", "Ciudad Real", null, "Descripcion de prueba 1, ruta en ciudad real", 10, 1, 20);
            ruta1.formaLlegada = "En avion";
            ruta1.formaVuelta = "En coche";
            ruta1.Origen = "Alicante";
            ruta1.Destino = "Jaén";
            ruta1.guia= guia1;
            ruta1.participantes.Add(part1);
            ruta1.participantes.Add(part2);
            ruta1.puntosInteres.Add(punto1);
            ruta1.puntosInteres.Add(punto3);
            List<string> listaIncidenciasAux = new List<string> { "Me hablaron feo", "El guia no era guapo", "Mucho calor y poca agua", "Poca comida", "Mal guiado" };
            List<string> listaMaterialesAux = new List<string> { "mochila", "gafas", "Botas de montaña buenas" };
            ruta1.incidencias = listaIncidenciasAux;
            ruta1.material = listaMaterialesAux;
            ruta1.FechayHora = DateTime.Parse("18/03/2023");
            ruta1.seCome = true;
            ruta1.Mapa = new Uri("/mapaCiu.jpeg", UriKind.Relative);
            ruta1.Imagenlista = new Uri("/mapaCiu.jpeg", UriKind.Relative);

            Ruta ruta2 = new Ruta("Ruta B", "Madrid", null, "Descripcion de prueba 2, ruta en Madrid", 10, 1, 20);
            ruta2.Finalizada = true;
            ruta2.formaLlegada = "En autobus";
            ruta2.formaVuelta = "En autobus";
            ruta2.Origen = "Toledo";
            ruta2.Destino = "Toledo";
            ruta2.guia = guia2; 
            ruta2.participantes.Add(part3);
            ruta2.participantes.Add(part2);
            ruta2.puntosInteres.Add(punto2);
            ruta2.puntosInteres.Add(punto4);
            List<string> listaIncidenciasAux2 = new List<string> { "Estaba cerrado", "Mal temporal", "No habia baño", "Mucha gente", "Muy caro" };
            List<string> listaMaterialesAux2 = new List<string> { "Mochila", "Botella de agua", "Calzado cómodo" };
            ruta2.incidencias = listaIncidenciasAux2;
            ruta2.material = listaMaterialesAux2;
            ruta2.FechayHora = DateTime.Parse("20/11/2021");
            ruta2.Mapa = new Uri("/mapaMadrid.jpeg", UriKind.Relative);
            ruta2.Imagenlista = new Uri("/mapaMadrid.jpeg", UriKind.Relative);
            Listarutas.Items.Add(ruta1);
            Listarutas.Items.Add(ruta2);
            original.Add(ruta1);
            original.Add(ruta2);

        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeRutas*/

        private void Listarutas_SelectionChanged(object sender, SelectionChangedEventArgs e) // Terminado
        {
            estadoBotones(true);
            ActualizarVentana();
           

        }
        private void btnX_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Listarutas.SelectedItem = null;
            mapa.Visibility = Visibility.Hidden;
            estadoBotones(false);
            lblNombreruta2.Content = "";
            lblDescripcion2.Content = "";
            lblpartic2.Content = "";
        }
        private void Btn_Ayuda_Click(object sender, RoutedEventArgs e) // Terminado
        {
            MessageBox.Show("Para consultar los detalles, participantes y demás datos de una ruta, seleccione una de la lista de la izquierda\n", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnFinalizar_Click(object sender, RoutedEventArgs e) // Terminado
        {
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere finalizar la ruta?.", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                lblFinalizar.Visibility = Visibility.Visible;
                Ruta seleccionada = Listarutas.SelectedItem as Ruta;
                seleccionada.Finalizada = true;
                btnFinalizar.IsEnabled = false;
            }
        }
        private void Btn_BorrarRuta_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            System.Windows.MessageBoxResult result = MessageBox.Show("¿Está seguro que quiere borrar la ruta?.", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if  (result == MessageBoxResult.OK)
            {
                Listarutas.Items.Remove(seleccionada);
            }
        }
        private void txbBuscar_TextChanged(object sender, TextChangedEventArgs e) // Terminado
        {
            Listarutas.SelectedItem = null;
            mapa.Visibility = Visibility.Hidden;
            estadoBotones(false);
            lblNombreruta2.Content = "";
            lblDescripcion2.Content = "";
            lblpartic2.Content = "";
            Ruta b = new Ruta();
            ObservableCollection<Ruta> aux = new ObservableCollection<Ruta>();
            foreach (Ruta item in Listarutas.Items)
            {


                if (item.Nombre.ToString().ToLower().Contains(txbBuscar.Text.ToLower()))
                {
                    aux.Add(item);
                }

            }
            while (Listarutas.Items.Count > 0)
            {
                Listarutas.Items.RemoveAt(0);
            }
            foreach (Ruta item in aux)
            {
                Listarutas.Items.Add(item);
            }


        }
        private void txbBuscar_KeyUp(object sender, KeyEventArgs e) // Terminado
        {
            if (e.Key == Key.Back && txbBuscar.Text == "")
            {
                Listarutas.Items.Clear();
                foreach (Ruta item in original)
                {
                    Listarutas.Items.Add(item);
                }
            }
        }
        private void txbBuscar_GotFocus(object sender, RoutedEventArgs e) // Terminado
        {
            txbBuscar.Text = "";
        }

        /**************************************************************/

        /*Botones Reservados para la creacion de las Ventanas derivadas*/

        /*Boton reservado para la Ventana Participantes*/
        private void btnParticipantes_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            Participantes ventanaParticipantes = new Participantes(seleccionada);
            ventanaParticipantes.ShowDialog();
            ActualizarVentana();
        }
        /*Boton reservado para la Ventana PuntosDeInteres*/
        private void btnPuntos_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            PuntosDeInteres ventanaPuntosDeInteres = new PuntosDeInteres(seleccionada);
            ventanaPuntosDeInteres.ShowDialog();
            ActualizarVentana();
        }
        /*Botones reservados para la Ventana DetallesRuta*/
        private void Btn_AñadirRuta_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Ruta nuevaRuta = new Ruta("Nueva Ruta", "", null, "", 0, 1, 0);
            Listarutas.Items.Add(nuevaRuta);
            DetallesRuta ventanaDetallesRuta = new DetallesRuta(nuevaRuta, listadoGuias);
            /*Utilizamos ShowDialog ya que vamos esperar a que la otra ventana se cierre para luego despues actualizarla correctamente*/
            ventanaDetallesRuta.ShowDialog();
            if (ventanaDetallesRuta.OperacionCompletada != true)
            {
                Listarutas.Items.Remove(nuevaRuta);
            }
            nuevaRuta = ventanaDetallesRuta.Result;
            ActualizarVentana();
        }
        private void btnRuta_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            DetallesRuta ventanaDetallesRuta = new DetallesRuta(seleccionada,listadoGuias);
            /*Utilizamos ShowDialog ya que vamos esperar a que la otra ventana se cierre para luego despues actualizarla correctamente*/
            ventanaDetallesRuta.ShowDialog();
            if (ventanaDetallesRuta.OperacionCompletada == true)
            {
                seleccionada = ventanaDetallesRuta.Result;
            }
            ActualizarVentana();
        }

        /**************************************************************/

        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void ActualizarVentana() // Terminado
        {
            Listarutas.Items.Refresh();
            Ruta seleccionada = Listarutas.SelectedItem as Ruta;
            if (seleccionada != null)
            {
                // Cargamos la foto de la ruta en la Image de nuestra interfaz
                if (seleccionada.Mapa != null)
                {
                    BitmapImage imagen = new BitmapImage(seleccionada.Mapa);
                    mapa.Source = imagen;
                    mapa.Visibility = Visibility.Visible;
                }
                else
                {
                    mapa.Source = null;
                    mapa.Visibility = Visibility.Hidden;
                }

                lblNombreruta2.Content = seleccionada.Nombre;
                lblDescripcion2.Content = seleccionada.Descripcion;
                if (seleccionada.participantes != null)
                {
                    lblpartic2.Content = seleccionada.participantes.Count() + " / " + seleccionada.maxParticipantes;
                }
               
                if (seleccionada.Finalizada == true)
                {
                    lblFinalizar.Visibility = Visibility.Visible;
                    btnFinalizar.IsEnabled = false;
                }
                else
                {
                    lblFinalizar.Visibility = Visibility.Hidden;
                    btnFinalizar.IsEnabled = true;
                }
            }
        }
        private void estadoBotones(bool estado) // Terminado
        {
            btnRuta.IsEnabled = estado;
            btnParticipantes.IsEnabled = estado;
            btnPuntos.IsEnabled = estado;
            btnFinalizar.IsEnabled = estado;
        }
    }
}