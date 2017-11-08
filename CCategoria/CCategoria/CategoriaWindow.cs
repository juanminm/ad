using System;
using System.Data;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow(Categoria categoria) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            Title = "Categoria";

            entryNombre.Text = categoria.Nombre;

            saveAction.Activated += delegate
            {
                categoria.Nombre = entryNombre.Text;
                CategoriaDao.Save(categoria);
                Destroy();
            };
        }
    }
}
