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

        TreeViewHelper.Fill(treeView, "SELECT * FROM `categoria` "
                + "ORDER BY `id`");

        newAction.Activated += delegate
        {
            new CategoriaWindow(new Categoria());
        };

        refreshAction.Activated += delegate
        {
            TreeViewHelper.Fill(treeView, "SELECT * FROM `categoria` ORDER BY "
                    + "`id`");
        };

        treeView.Selection.Changed += delegate
        {
            bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
            deleteAction.Sensitive = hasSelected;
            editAction.Sensitive = hasSelected;
        };

        deleteAction.Activated += delegate
        {
            if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
            {
                Categoria categoria = CategoriaDao.Load(
                    TreeViewHelper.GetId(treeView));
                CategoriaDao.Delete(categoria);
            }
        };

        editAction.Activated += delegate
        {
            new CategoriaWindow(CategoriaDao.Load(
                TreeViewHelper.GetId(treeView)));
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        App.Instance.Connection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
