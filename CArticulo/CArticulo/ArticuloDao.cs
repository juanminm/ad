using System;
using System.Data;

using Serpis.Ad;

namespace CArticulo
{
    public class ArticuloDao
    {
        public static void Save(Articulo articulo)
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            dbCommand.CommandText = "INSERT INTO `articulo` (`nombre`, " +
                "`categoria`, `precio`) VALUES (@nombre, @categoria, @precio);";
            
            DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
            DbCommandHelper.AddParameter(dbCommand, "categoria",
                                         articulo.CategoriaId);
            DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);

            dbCommand.ExecuteNonQuery();
        }
    }
}
