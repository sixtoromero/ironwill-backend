using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
