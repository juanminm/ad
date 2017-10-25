using System;
using System.Data;

using Serpis.Ad;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow(object id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            Title = "Categoria";
            Categoria categoria = CategoriaDao.Load(id);
            entryNombre.Text = categoria.Nombre;

            saveAction.Activated += delegate
            {
                categoria.Nombre = entryNombre.Text;
                CategoriaDao.Save(categoria);
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
                Categoria categoria = new Categoria();
                categoria.Nombre = entryNombre.Text;

                CategoriaDao.Save(categoria);
                Destroy();
            };
        }
    }
}
