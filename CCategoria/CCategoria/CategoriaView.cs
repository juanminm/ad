using System;
using System.Data;

namespace CCategoria
{
    public partial class CategoriaView : Gtk.Window
    {
        public CategoriaView() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            saveAction.Activated += delegate {
                IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
                dbCommand.CommandText = "INSERT INTO `categoria` (`nombre`) " +
                    "VALUES (@nombre)";
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "nombre";
                dbDataParameter.Value = entryNombre.Text;
                dbCommand.Parameters.Add(dbDataParameter);
                dbCommand.ExecuteNonQuery();

                Destroy();
            };
        }
    }
}
