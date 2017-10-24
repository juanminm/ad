using System;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			Title = "Categoria";

			saveAction.Activated += delegate
			{
				IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

				dbCommand.CommandText = "INSERT INTO `categoria` (`nombre`) "
					+ "VALUES (@nombre)";
				DbCommandHelper.AddParameter(dbCommand, "nombre",
											 entryNombre.Text);

				dbCommand.ExecuteNonQuery();

				Destroy();
			};
		}
	}
}
