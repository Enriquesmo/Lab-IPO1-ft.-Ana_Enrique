using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HECHA

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class Ruta
    {
        public string Nombre { set; get; } //
        public string Provincia { set; get; } //
        public int Duracion { set; get; } //
        public String Dificultad { get; set; } //
        public ObservableCollection<Excursionista> participantes { get; set; } //id es telefono
        public int maxParticipantes { get; set; } //                                  
        public ObservableCollection<string> puntosInteres { get; set; } //id es nombre
        public string formaLlegada { get; set; }
        public string formaVuelta { get; set; }
        public List<string> material { get; set; }
        public bool seCome { set; get; }
        public Guia guia { get; set; } //id es telefono // AUN HAY QUE HACERLO
        public string Descripcion { set; get; } //
        public string Origen { set; get; }
        public string Destino { set; get; }
        public DateTime FechayHora { get; set; }
        public bool Finalizada { set; get; } //
        public Uri Mapa { set; get; } //
        public Uri Imagenlista { set; get; }
        public List<string> incidencias { get; set; }

        public Ruta(string nombre, string provincia, Uri mapa, string descripcion, int duracion, int dificultad, int maxPart) { 
            if (dificultad == 1)
            {
                Dificultad = "Facil";
            }
            else if (dificultad == 2)
            {
                Dificultad = "Media";
            }
            else if (dificultad == 3)
            {
                Dificultad = "Dificil";
            }
            Nombre = nombre;
            Provincia = provincia;
            Mapa = mapa;
            Descripcion = descripcion;
            Duracion = duracion;
            maxParticipantes = maxPart;
            participantes = new ObservableCollection<Excursionista>();

        } 
    }
}
