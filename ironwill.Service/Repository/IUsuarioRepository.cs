using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface IUsuarioRepository
    {
        Task<string> InsertAsync(Usuarios model);
        Task<string> UpdateAsync(Usuarios model);
        Task<string> DeleteAsync(int IdUsuario);

        Task<Usuarios> getUserByLogin(string Correo, string Clave);        
        
    }
}
