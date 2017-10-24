using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;

using Serpis.Ad;
using CCategoria;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Title = "Categoria";

        deleteAction.Sensitive = false;
        editAction.Sensitive = false;

        App.Instance.Connection = new MySqlConnection("server=localhost;"
                + "database=dbprueba;user=root;password=sistemas");
        App.Instance.Connection.Open();

        TreeViewHelper.SetListStore(treeView, "id", "nombre");

        TreeViewHelper.Fill(treeView, "SELECT `id`, `nombre` FROM `categoria` "
                            + "ORDER BY `id`");

        newAction.Activated += delegate
        {
            new CategoriaWindow();
        };

        refreshAction.Activated += delegate
        {
            ((ListStore)treeView.Model).Clear();

            TreeViewHelper.Fill(treeView, "SELECT * FROM `categoria` ORDER BY "
                                + "`id`");
        };

        treeView.Selection.Changed += delegate {
            bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
            deleteAction.Sensitive = hasSelected;
            editAction.Sensitive = hasSelected;
        };

        deleteAction.Activated += delegate
        {
            if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
            {
                IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

                dbCommand.CommandText = "DELETE FROM `categoria` (`nombre`) " +
                    "WHERE `id` = @id";
                DbCommandHelper.AddParameter(dbCommand, "id", GetId());
                dbCommand.ExecuteNonQuery();
            }
        };

        editAction.Activated += delegate
        {
			object id = GetId();
			new CategoriaWindow(id);
        };
    }

    private object GetId()
    {
        treeView.Selection.GetSelected(out TreeIter treeIter);
        return treeView.Model.GetValue(treeIter, 0);
    }

    private void FillListStore(ListStore listStore)
    {
        IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
        IDataReader dataReader;
        dbCommand.CommandText = "SELECT * FROM `categoria` ORDER BY `id`";
        dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())
        {
            listStore.AppendValues(dataReader["id"].ToString(),
                                   dataReader["nombre"].ToString());
        }
        dataReader.Close();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        App.Instance.Connection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
