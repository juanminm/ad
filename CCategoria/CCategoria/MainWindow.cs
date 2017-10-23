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

        deleteAction.Sensitive = false;

        App.Instance.Connection = new MySqlConnection("server=localhost;"
                + "database=dbprueba;user=root;password=sistemas");
        App.Instance.Connection.Open();

        TreeViewHelper.SetListStore(treeView, "id", "nombre", "contraseña");

        TreeViewHelper.Fill(treeView, "SELECT `id`, `nombre` FROM `categoria` "
                            + "ORDER BY `id`");

        newAction.Activated += delegate {
            new CategoriaView();
        };

        refreshAction.Activated += delegate {
            ((ListStore)treeView.Model).Clear();

            TreeViewHelper.Fill(treeView, "SELECT * FROM `categoria` ORDER BY "
                                + "`id`");
        };

        treeView.Selection.Changed += delegate {
            deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
        };

        deleteAction.Activated += delegate {
            MessageDialog messageDialog = new MessageDialog(
                this, DialogFlags.Modal, MessageType.Question,
                ButtonsType.YesNo, "¿Quieres eliminar el registro?");

            ResponseType response = (ResponseType)messageDialog.Run();
            if (response == ResponseType.Yes)
            {
                IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

                treeView.Selection.GetSelected(out TreeIter treeIter);

                dbCommand.CommandText = "DELETE FROM `categoria` (`nombre`) " +
                    "WHERE `id` = @id";
                DbCommandHelper.AddParameter(dbCommand, "id",
                                             treeView.Model.GetValue(treeIter, 0));
                dbCommand.ExecuteNonQuery();

                Destroy();
            }
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        App.Instance.Connection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
