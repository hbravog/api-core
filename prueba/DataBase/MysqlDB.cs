using System;
using System.Data;
using IntegracionSistemas.Model;
using MySql.Data.MySqlClient;

namespace IntegracionSistemas.DataBase
{
    public class MysqlDB : IDisposable
    {
        public MySqlConnection Connection { get; }

        public MysqlDB()
        { string connectionString = "server=mysqlintegracion.mysql.database.azure.com;user id=integracion@mysqlintegracion;password=Duoc2020;port=3306;database=integracion;";
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public void BindParams(MySqlCommand cmd, Persona persona)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Nombre",
                DbType = DbType.String,
                Value = persona.Nombre,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Email",
                DbType = DbType.String,
                Value = persona.Email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Edad",
                DbType = DbType.Int32,
                Value = persona.Edad,
            });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
