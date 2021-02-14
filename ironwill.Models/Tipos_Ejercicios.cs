using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Tipos_Ejercicios
    {
        public int IdTipoEjercicio { get; set; }
        public int IdUsuario { get; set; }
        public string Ejercicio { get; set; }
        public DateTime Fecha_Creacion { get; set; }        
    }
}
