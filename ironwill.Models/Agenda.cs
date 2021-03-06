using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Agenda
    {
        public int IdAgenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoEjercicio { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        public string Deportista { get; set; }
        public string Ejercicio { get; set; }

    }
}
