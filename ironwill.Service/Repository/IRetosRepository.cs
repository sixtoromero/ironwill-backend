using Dapper;
using ironwill.Models;
using ironwill.Service.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public class IRetosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public IRetosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Retos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertRetos";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Reto", model.Reto);
                parameters.Add("Peso", model.Peso);
                parameters.Add("Tiempo", model.Tiempo);
                parameters.Add("Logro", model.Logro);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Retos model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateRetos";
                var parameters = new DynamicParameters();

                parameters.Add("IdRetos", model.IdReto);
                parameters.Add("Reto", model.Reto);
                parameters.Add("Peso", model.Peso);
                parameters.Add("Tiempo", model.Tiempo);
                parameters.Add("Logro", model.Logro);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdRetos)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteRetos";
                var parameters = new DynamicParameters();

                parameters.Add("IdRetos", IdRetos);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Retos>> getRetos(int IdUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetRetos";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", IdUsuario);

                var result = await connection.QuerySingleAsync<IEnumerable<Retos>>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
