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
    public class Tipos_EjerciciosRepository : ITipos_EjerciciosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public Tipos_EjerciciosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Tipos_Ejercicios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertTipos_Ejercicios";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Ejercicio", model.Ejercicio);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Tipos_Ejercicios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateTipos_Ejercicios";
                var parameters = new DynamicParameters();

                parameters.Add("IdTipoEjercicio", model.IdTipoEjercicio);
                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Ejercicio", model.Ejercicio);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdTipos_Ejercicios)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteTipos_Ejercicios";
                var parameters = new DynamicParameters();

                parameters.Add("IdTipoEjercicio", IdTipos_Ejercicios);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Tipos_Ejercicios>> getTipos_Ejercicios()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetTipos_Ejercicios";

                var result = await connection.QueryAsync<Tipos_Ejercicios>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }        

    }
}
