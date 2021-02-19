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
    public class Perfil_Profesional_InstructorRepository : IPerfil_Profesional_InstructorRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public Perfil_Profesional_InstructorRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Perfil_Profesional_Instructor model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertPerfilProfesional";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("Perfil_Profesional", model.Perfil_Profesional);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Perfil_Profesional_Instructor model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdatePerfilProfesional";
                var parameters = new DynamicParameters();

                parameters.Add("IdPerfilProfesionalInst", model.IdPerfilProfesionalInst);
                parameters.Add("TipoDocumento", model.IdUsuario);
                parameters.Add("Documento", model.Perfil_Profesional);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int IdPerfilProfesionalInst)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeletePerfilProfesional";
                var parameters = new DynamicParameters();

                parameters.Add("IdPerfilProfesionalInst", IdPerfilProfesionalInst);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
        
        public async Task<IEnumerable<Perfil_Profesional_Instructor>> getPerfilProfesionalInst(int IdUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPerfilPro";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", IdUsuario);

                var result = await connection.QuerySingleAsync<IEnumerable<Perfil_Profesional_Instructor>>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
