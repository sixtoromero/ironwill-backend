using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Recomendaciones
    {
        public int IdRecomendacion { get; set; }
        public int IdUsuario { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }        
    }
}
