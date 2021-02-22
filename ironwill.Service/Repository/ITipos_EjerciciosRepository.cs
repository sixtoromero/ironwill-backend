using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface ITipos_EjerciciosRepository
    {
        Task<string> InsertAsync(Tipos_Ejercicios model);
        Task<string> UpdateAsync(Tipos_Ejercicios model);
        Task<string> DeleteAsync(int IdTipoEjercicio);

        Task<IEnumerable<Tipos_Ejercicios>> getTipos_Ejercicios(int IdUsuario);
    }
}
