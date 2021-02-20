using Dapper;
using ironwill.Models;
using ironwill.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironwill.Service.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AgendaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Agenda model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertAgenda";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("IdTipoEjercicio", model.IdTipoEjercicio);
                parameters.Add("Fecha", model.Fecha);
                parameters.Add("Hora", model.Hora);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Agenda model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateAgenda";
                var parameters = new DynamicParameters();

                parameters.Add("IdAgenda", model.IdAgenda);
                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("IdTipoEjercicio", model.IdTipoEjercicio);
                parameters.Add("Fecha", model.Fecha);
                parameters.Add("Hora", model.Hora);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdAgenda)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteAgenda";
                var parameters = new DynamicParameters();

                parameters.Add("IdAgenda", IdAgenda);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Agenda>> getAgenda(int IdUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetAgenda";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", IdUsuario);

                var result = await connection.QuerySingleAsync<IEnumerable<Agenda>>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
