using System;
using System.Collections.Generic;
using System.Text;

namespace ironwill.Models
{
    public class Perfil_Profesional_Instructor
    {
        public int IdPerfilProfesionalInst { get; set; }
        public int IdUsuario { get; set; }
        public string Perfil_Profesional { get; set; }
        public DateTime Fecha_Creacion { get; set; }        
    }
}
