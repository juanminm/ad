using System;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        object id;
        public CategoriaWindow(object id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            Title = "Categoria";
            this.id = id;

            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM `categoria` " +
                "WHERE `id` = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            IDataReader dataReader = dbCommand.ExecuteReader();
            dataReader.Read(); //TODO tratamiento de excepciones
            string nombre = (string)dataReader["nombre"];
            dataReader.Close();
            entryNombre.Text = nombre;

            saveAction.Activated += delegate
            {
                Update();
                Destroy();
            };

        }

        public CategoriaWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            Title = "Categoria";

            saveAction.Activated += delegate
            {
                Insert();
                Destroy();
            };
        }

        private void Insert()
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            dbCommand.CommandText = "INSERT INTO `categoria` (`nombre`) "
                + "VALUES (@nombre)";
            DbCommandHelper.AddParameter(dbCommand, "nombre",
                                         entryNombre.Text);

            dbCommand.ExecuteNonQuery();
        }

        private void Update()
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = "UPDATE `categoria` SET `nombre` = " +
                "@nombre WHERE `id` = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            DbCommandHelper.AddParameter(dbCommand, "nombre", entryNombre.Text);
            dbCommand.ExecuteNonQuery();
        }
    }
}
