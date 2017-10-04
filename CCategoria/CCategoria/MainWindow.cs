using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;

using CCategoria;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        App.Instance.Connection = new MySqlConnection("server=localhost;database"
                + "=dbprueba;user=root;password=sistemas");
        App.Instance.Connection.Open();

        treeView.AppendColumn("id", new CellRendererText(), "text", 0);
        treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
        ListStore listStore = new ListStore(typeof(string), typeof(string));
		treeView.Model = listStore;

		String[,] arrayDatos = ObtenerDatos();

        for (int i = 0; i < arrayDatos.GetLength(0); i++)
        {
            listStore.AppendValues(arrayDatos[i, 0], arrayDatos[i, 1]);
        }

        newAction.Activated += delegate {
            new CategoriaView();
		};
    }

	private String[,] ObtenerDatos()
	{
		String[,] arrayDatos;
		IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
		IDataReader dataReader;
		int count = 0;

		dbCommand.CommandText = "SELECT COUNT(*) FROM categoria";
		dataReader = dbCommand.ExecuteReader();
		dataReader.Read();
		count = dataReader.GetInt32(0);
		dataReader.Close();

		arrayDatos = new String[count, 2];
		dbCommand.CommandText = "SELECT * FROM categoria";
		dataReader = dbCommand.ExecuteReader();

		for (int i = 0; dataReader.Read(); i++)
		{
			arrayDatos[i, 0] = dataReader.GetString(0);
			arrayDatos[i, 1] = dataReader.GetString(1);
		}

		dataReader.Close();
		return arrayDatos;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
		App.Instance.Connection.Close();
		Application.Quit();
        a.RetVal = true;
    }
}
