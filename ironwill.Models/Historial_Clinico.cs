using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Historial_Clinico
    {
        public int IdHistorialClinico { get; set; }
        public int IdUsuario { get; set; }
        public string Observacion { get; set; }
        public decimal Peso { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
