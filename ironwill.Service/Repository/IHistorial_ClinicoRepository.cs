using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface IHistorial_ClinicoRepository
    {
        Task<string> InsertAsync(Historial_Clinico model);
        Task<string> UpdateAsync(Historial_Clinico model);
        Task<string> DeleteAsync(int IdHistorialClinico);

        Task<IEnumerable<Historial_Clinico>> getHistorial_Clinico(int IdUsuario);
    }
}
