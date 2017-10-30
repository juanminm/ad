using System;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public class CategoriaDao
    {
        public static Categoria Load(object id)
        {
            Categoria categoria = new Categoria();
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            IDataReader dataReader;

            dbCommand.CommandText = "SELECT * FROM `categoria` " +
                "WHERE `id` = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            dataReader = dbCommand.ExecuteReader();
            dataReader.Read(); //TODO tratamiento de excepciones

            categoria.Id = Convert.ToInt64(id);
            categoria.Nombre = (string)dataReader["nombre"];
            dataReader.Close();

            return categoria;
        }

        public static void Save(Categoria categoria) {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            if (categoria.Id == 0)
            {
                dbCommand.CommandText = "INSERT INTO `categoria` (`nombre`) "
                    + "VALUES (@nombre)";
                DbCommandHelper.AddParameter(dbCommand, "nombre",
                                             categoria.Nombre);
            }
            else
            {
                dbCommand.CommandText = "UPDATE `categoria` SET `nombre` = " +
                    "@nombre WHERE `id` = @id";
                DbCommandHelper.AddParameter(dbCommand, "id", categoria.Id);
                DbCommandHelper.AddParameter(dbCommand, "nombre",
                                             categoria.Nombre);
            }

            dbCommand.ExecuteNonQuery();
        }

        public static void Delete(Categoria categoria) {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            dbCommand.CommandText = "DELETE FROM `categoria` WHERE `id` = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", categoria.Id);
            dbCommand.ExecuteNonQuery();
        }
    }
}
