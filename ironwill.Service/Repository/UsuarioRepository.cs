using ironwill.Models;
using ironwill.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ironwill.Service.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspInsertUsuario";
                var parameters = new DynamicParameters();

                parameters.Add("TipoDocumento", model.TipoDocumento);
                parameters.Add("Documento", model.Documento);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Celular", model.Celular);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Clave", model.Clave);
                parameters.Add("Genero", model.Genero);
                parameters.Add("Fecha_Nacimiento", model.Fecha_Nacimiento);
                parameters.Add("Estado", model.Estado);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUpdateUsuario";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("TipoDocumento", model.TipoDocumento);
                parameters.Add("Documento", model.Documento);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("Direccion", model.Direccion);
                parameters.Add("Celular", model.Celular);
                parameters.Add("Correo", model.Correo);
                parameters.Add("Clave", model.Clave);
                parameters.Add("Genero", model.Genero);
                parameters.Add("Fecha_Nacimiento", model.Fecha_Nacimiento);
                parameters.Add("Estado", model.Estado);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDeleteUsuario";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);                

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
