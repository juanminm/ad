using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CMySql
{
    class MainClass
    {
        private static IDbConnection connection;

        public static void Main(string[] args)
        {
            String connStr = "server=localhost;database=dbprueba;user=root;" +
             "password=sistemas";
            connection = new MySqlConnection(connStr);
            connection.Open();

            CrearCategoria();
            //ModificarCategoria();
            //EliminarCategoria();
            LeerCategoria();

            connection.Close();
        }

		/*
		 * Para consultas.
		 */
		private static void LeerCategoria() {
			IDbCommand dbCommand = connection.CreateCommand();
			IDataReader dataReader;

            dbCommand.CommandText = "SELECT * FROM categoria";
			dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
                Console.WriteLine("id={0} nombre={1}", dataReader["id"],
                                  dataReader["nombre"]);

            dataReader.Close();
        }

		/*
         * Para crear, modificar y eliminar tablas e insertar, actualizar y
         * eliminar datos.
         */
		private static void CrearCategoria()
		{
			IDbCommand dbCommand = connection.CreateCommand();

			dbCommand.CommandText = "INSERT INTO `categoria` (`nombre`) " +
				"VALUES (@nombre);";
			addParameter(dbCommand, "nombre", "categoría 6");
			dbCommand.ExecuteNonQuery();
		}

        private static void addParameter(IDbCommand dbCommand, string name,
                                         object value)
        {
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
        }

		/*
         * Para crear, modificar y eliminar tablas e insertar, actualizar y
         * eliminar datos.
         */
		private static void ModificarCategoria()
		{
			IDbCommand dbCommand = connection.CreateCommand();

			dbCommand.CommandText = "UPDATE  `categoria` SET " +
                "`nombre`='Categoria5') WHERE `id` = 4;";
			dbCommand.ExecuteNonQuery();
		}


		/*
         * Para crear, modificar y eliminar tablas e insertar, actualizar y
         * eliminar datos.
         */
		private static void EliminarCategoria()
		{
			IDbCommand dbCommand = connection.CreateCommand();

			dbCommand.CommandText = "DELETE FROM `categoria` WHERE `id` = 4;";
			dbCommand.ExecuteNonQuery();
		}

	}
}
