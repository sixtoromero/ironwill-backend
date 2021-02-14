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
    }
}
