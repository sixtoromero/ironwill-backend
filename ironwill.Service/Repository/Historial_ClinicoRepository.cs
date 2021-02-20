using Dapper;
using ironwill.Models;
using ironwill.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public class Historial_ClinicoRepository : IHistorial_ClinicoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public Historial_ClinicoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Historial_Clinico model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertHistorial_Clinico";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Observacion", model.Observacion);
                parameters.Add("Peso", model.Peso);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Historial_Clinico model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateHistorial_Clinico";
                var parameters = new DynamicParameters();

                parameters.Add("IdHistorialClinico", model.IdHistorialClinico);
                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Observacion", model.Observacion);
                parameters.Add("Peso", model.Peso);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdHistorialClinico)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteHistorial_Clinico";
                var parameters = new DynamicParameters();

                parameters.Add("IdHistorialClinico", IdHistorialClinico);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Historial_Clinico>> getHistorial_Clinico(int IdUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetHistorial_Clinico";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", IdUsuario);

                var result = await connection.QuerySingleAsync<IEnumerable<Historial_Clinico>>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }



    }
}
