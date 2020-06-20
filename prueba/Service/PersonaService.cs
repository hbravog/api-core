using System;
using System.Collections.Generic;
using IntegracionSistemas.DataBase;
using IntegracionSistemas.Model;
using MySql.Data.MySqlClient;

namespace IntegracionSistemas.Service
{
    public class PersonaService
    {
        internal MysqlDB Db { get; set; }

        public PersonaService()
        {
        }

        internal PersonaService(MysqlDB db)
        {
            Db = db;
        }


        public List<Persona> GetPersona()
        {
            List<Persona> lista = new List<Persona>();
            Persona persona = null;
            MysqlDB mysql = new MysqlDB();
            var cmd = mysql.Connection.CreateCommand();
            cmd.CommandText = @"SELECT idPersona, Nombre,Email,Edad FROM `integracion`.Persona ";
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                persona = new Persona();
                persona.IdPersona = Int32.Parse(reader[0].ToString());
                persona.Nombre = reader[1].ToString();
                persona.Email = reader[2].ToString();
                persona.Edad = Int32.Parse(reader[3].ToString());
                lista.Add(persona);
            }
            return lista;
        }

        public string Insert(Persona persona)
        {
            string response = string.Empty;
            MysqlDB mysql = new MysqlDB();
            var cmd = mysql.Connection.CreateCommand();

            cmd.CommandText = @"INSERT INTO `integracion`.Persona (`Nombre`, `Email`,`Edad`) VALUES (@Nombre, @Email,@Edad);";
            mysql.BindParams(cmd, persona);
            try
            {
                cmd.ExecuteNonQuery();
                response = cmd.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
               response = ex.Message;
            }
            
            return response;
        }

        public string Update(int idPersona, Persona persona)
        {
            string response = string.Empty;
            MysqlDB mysql = new MysqlDB();
            var cmd = mysql.Connection.CreateCommand();

            cmd.CommandText = @"UPDATE integracion.persona SET Nombre=@Nombre, Email = @Email, Edad = @Edad  WHERE idPersona=" + idPersona + ";" ;
            mysql.BindParams(cmd, persona);
            try
            {
                cmd.ExecuteNonQuery();
                response = cmd.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public string Delete(int idPersona)
        {
            string response = string.Empty;
            MysqlDB mysql = new MysqlDB();
            var cmd = mysql.Connection.CreateCommand();

            cmd.CommandText = @"DELETE FROM integracion.persona WHERE idPersona=" + idPersona + ";";
            try
            {
                response = cmd.ExecuteNonQuery().ToString();
                
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }
    }
}
