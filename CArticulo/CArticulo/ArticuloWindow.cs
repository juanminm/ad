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

            comboCategoria.AddAttribute(new CellRendererText(), "text", 0);
            comboCategoria.Model = listStore;

            dbCommand.CommandText = "SELECT `id` FROM `categoria` ORDER BY 1;";
            dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                    row[i] = dataReader.GetValue(i).ToString();

                listStore.AppendValues(row);
            }


            spinPrecio.Value = (double)articulo.Precio;
        }
    }
}
