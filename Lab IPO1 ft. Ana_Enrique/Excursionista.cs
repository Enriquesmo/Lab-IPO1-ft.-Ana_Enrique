using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HECHO

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class Excursionista
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Uri Foto { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public List<Ruta> Rutas { get; set; }

        public Excursionista(string nombre, string apellidos, int edad, int telefono)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Edad = edad;

        }
    }
}
