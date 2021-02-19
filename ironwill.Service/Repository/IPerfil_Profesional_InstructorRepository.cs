using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface IPerfil_Profesional_InstructorRepository
    {
        Task<string> InsertAsync(Perfil_Profesional_Instructor model);
        Task<string> UpdateAsync(Perfil_Profesional_Instructor model);
        Task<string> DeleteAsync(int IdPerfilProfesionalInst);

        Task<IEnumerable<Perfil_Profesional_Instructor>> getPerfilProfesionalInst(int IdUsuario);

    }
}
