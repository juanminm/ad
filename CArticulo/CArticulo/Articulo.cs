using System;
using System;
namespace CArticulo
{
    public class Articulo
    {
        public Articulo()
        {
            nombre = "";
        }

        private long id;
        private string nombre;
        private long categoriaId;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public long CategoriaId
        {
            get { return categoriaId; }
            set { categoriaId = value; }
        }
    }
}