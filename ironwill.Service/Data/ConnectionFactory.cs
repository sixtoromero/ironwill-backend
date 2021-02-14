﻿using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ironwill.Service.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Nos va a permitir acceder a las propiedades de los diferentes proyectos
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Inyecta la configuraciòn de la interfaz de IConfiguration
        /// </summary>
        /// <param name="configuration"></param>
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método que nos permite acceder a la base de datos en GlobusConnection
        /// </summary>
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;
                sqlConnection.ConnectionString = _configuration.GetConnectionString("MyStringConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }


    }
}
