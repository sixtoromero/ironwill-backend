using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface IRecomendacionesRepository
    {
        Task<string> InsertAsync(Recomendaciones model);
        Task<string> UpdateAsync(Recomendaciones model);
        Task<string> DeleteAsync(int IdRecomendacion);

        Task<IEnumerable<Recomendaciones>> getRecomendaciones(int IdUsuario);
    }
}
