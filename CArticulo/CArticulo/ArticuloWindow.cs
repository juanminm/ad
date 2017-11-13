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

            ListStore listStore = new ListStore(typeof(string)); 

            entryNombre.Text = articulo.Nombre;

            ComboBoxHelper.Fill(comboCategoria, "SELECT `id` FROM `categoria`" +
                                "ORDER BY 1;");

            spinPrecio.Value = (double)articulo.Precio;

            saveAction.Activated += delegate
            {
                IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

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
