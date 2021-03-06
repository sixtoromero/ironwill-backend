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
    public class RecomendacionesRepository : IRecomendacionesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public RecomendacionesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Recomendaciones model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertRecomendaciones";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Observacion", model.Observacion);                

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Recomendaciones model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateRecomendaciones";
                var parameters = new DynamicParameters();

                parameters.Add("IdRecomendacion", model.IdRecomendacion);
                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Observacion", model.Observacion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdRecomendacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteRecomendaciones";
                var parameters = new DynamicParameters();

                parameters.Add("IdRecomendacion", IdRecomendacion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Recomendaciones>> getRecomendaciones(int IdUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetRecomendaciones";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", IdUsuario);

                var result = await connection.QuerySingleAsync<IEnumerable<Recomendaciones>>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
