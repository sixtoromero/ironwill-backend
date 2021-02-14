using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }

        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Genero { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        
    }
}
