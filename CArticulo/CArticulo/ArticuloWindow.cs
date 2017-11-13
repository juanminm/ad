using System;
using System.Data;
using Gtk;

using Serpis.Ad;

namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
    {
        public ArticuloWindow(Articulo articulo) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            IDataReader dataReader;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            ListStore listStore = new ListStore(typeof(string)); 

            entryNombre.Text = articulo.Nombre;

            ComboBoxHelper.Init(comboCategoria);

            dbCommand.CommandText = "SELECT `id` FROM `categoria` ORDER BY 1;";
            dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                    row[i] = dataReader.GetValue(i).ToString();

                listStore.AppendValues(row);
            }

            dataReader.Close();
            dbCommand.Parameters.Clear();

            spinPrecio.Value = (double)articulo.Precio;

            saveAction.Activated += delegate
            {
                articulo.Nombre = entryNombre.Text;
                articulo.CategoriaId = Convert.ToInt64(comboCategoria.ActiveText);
                articulo.Precio = (decimal)spinPrecio.Value;

                dbCommand.CommandText = "INSERT INTO `articulo` (`nombre`, " +
                    "`categoria`, `precio`) VALUES (@nombre, @categoria, " +
                    "@precio);";
                DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
                DbCommandHelper.AddParameter(dbCommand, "categoria", articulo.CategoriaId);
                DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);
                dbCommand.ExecuteNonQuery();
                Destroy();
            };
        }
    }
}
