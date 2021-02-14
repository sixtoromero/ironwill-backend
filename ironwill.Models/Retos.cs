using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Retos
    {
        public int IdReto { get; set; }
        public int IdUsuario { get; set; }
        public string Reto { get; set; }
        public decimal Peso { get; set; }
        public string Tiempo { get; set; }
        public bool Logro { get; set; }
        public DateTime Fecha_Creacion { get; set; }        
    }
}
