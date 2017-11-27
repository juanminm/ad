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

        deleteAction.Sensitive = false;
        editAction.Sensitive = false;

        App.Instance.Connection = new MySqlConnection(
            "server=localhost;database=dbprueba;user=root;password=sistemas");
        App.Instance.Connection.Open();

        TreeViewHelper.Fill(treeView, "SELECT * FROM `articulo` ORDER BY `id`;");

        newAction.Activated += delegate
        {
            new ArticuloWindow(new Articulo());
        };

        refreshAction.Activated += delegate
        {
            TreeViewHelper.Fill(treeView, "SELECT * FROM `articulo` " +
                                "ORDER BY `id`;");
        };

        treeView.Selection.Changed += delegate
        {
            bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
            deleteAction.Sensitive = hasSelected;
            editAction.Sensitive = hasSelected;
        };

        editAction.Activated += delegate
        {
            object id = TreeViewHelper.GetId(treeView);
            Articulo articulo = ArticuloDao.Load(id);
            new ArticuloWindow(articulo);
        };

        deleteAction.Activated += delegate
        {
            if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
            {
                Articulo articulo = ArticuloDao.Load(
                    TreeViewHelper.GetId(treeView));
                ArticuloDao.Delete(articulo);
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
