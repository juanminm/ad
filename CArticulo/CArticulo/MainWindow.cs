using MySql.Data.MySqlClient;
using System;
using Gtk;

using CArticulo;
using Serpis.Ad;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        App.Instance.Connection = new MySqlConnection(
            "server=localhost;database=dbprueba;user=root;password=sistemas");
        App.Instance.Connection.Open();

        TreeViewHelper.Fill(treeView, "SELECT * FROM `articulo` ORDER BY `id`;");

        newAction.Activated += delegate {
            new ArticuloWindow(new Articulo());
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        App.Instance.Connection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
