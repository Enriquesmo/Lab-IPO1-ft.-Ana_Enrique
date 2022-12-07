using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

// HECHO

namespace Lab_IPO1_ft.Ana_Enrique
{
    public class Guia
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Uri Foto { get;set; }
        public List<string> Idiomas { get; set; }
        public List<string> Restricciones { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public List<Ruta> Rutas { get; set; }
        public int Puntuacion { get; set; }

        public Guia(string nombre, string apellidos, Uri foto, int telefono, string correo, int puntuacion)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Foto = foto;
            Telefono = telefono;
            Correo = correo;
            Puntuacion = puntuacion;

        }
    }
}
