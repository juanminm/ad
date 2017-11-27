using System;
using System.Data;

using Serpis.Ad;

namespace CArticulo
{
    public class ArticuloDao
    {

        public static Articulo Load(object id) {
            Articulo articulo;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM `articulo` WHERE `id` = @id;";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            IDataReader dataReader = dbCommand.ExecuteReader();
            string nombre;
            decimal precio;
            long categoria;

            dataReader.Read();

            nombre = (string)dataReader["nombre"];
            precio = (decimal)dataReader["precio"];
            categoria = dataReader["categoria"] is DBNull ? 0 :
                (long)dataReader["categoria"];
            dataReader.Close();

            articulo = new Articulo();
            articulo.Nombre = nombre;
            articulo.Precio = precio;
            articulo.CategoriaId = categoria;

            return articulo;
        }

        public static void Save(Articulo articulo)
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            if (articulo.CategoriaId == 0)
            {
                object categoria;

                dbCommand.CommandText = "INSERT INTO `articulo` (`nombre`, " +
                    "`categoria`, `precio`) VALUES (@nombre, @categoria, " +
                    "@precio);";

                categoria = articulo.CategoriaId == 0 ? (object)null :
                                           articulo.CategoriaId;

                DbCommandHelper.AddParameter(dbCommand, "nombre",
                                             articulo.Nombre);
                DbCommandHelper.AddParameter(dbCommand, "precio",
                                             articulo.Precio);
                DbCommandHelper.AddParameter(dbCommand, "categoria", categoria);


            } else {
                dbCommand.CommandText = "UPDATE `articulo` SET `nombre` = " +
                    "@nombre, `categoria` = @categoria, `precio` = @precio " +
                    "WHERE `id` = @id;";

                DbCommandHelper.AddParameter(dbCommand, "nombre",
                                             articulo.Nombre);
                DbCommandHelper.AddParameter(dbCommand, "precio",
                                             articulo.Precio);
                DbCommandHelper.AddParameter(dbCommand, "categoria",
                                             articulo.CategoriaId);
            }

            dbCommand.ExecuteNonQuery();
        }

        public static void Delete(Articulo articulo)
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            dbCommand.CommandText = "DELETE FROM `categoria` WHERE `id` = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", articulo.Id);
            dbCommand.ExecuteNonQuery();
        }
    }
}
