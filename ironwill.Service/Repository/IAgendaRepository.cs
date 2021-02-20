using ironwill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public interface IAgendaRepository
    {
        Task<string> InsertAsync(Agenda model);
        Task<string> UpdateAsync(Agenda model);
        Task<string> DeleteAsync(int IdAgenda);

        Task<IEnumerable<Agenda>> getAgenda(int IdUsuario);
    }
}
