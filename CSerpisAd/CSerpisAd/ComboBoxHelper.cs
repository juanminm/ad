using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
    public class ComboBoxHelper
    {
        public static void Init(ComboBox comboBox)
        {
            if (comboBox.Model != null)
                return;

            comboBox.AddAttribute(new CellRendererText(), "text", 0);

            ListStore listStore = new ListStore(typeof(string));
            comboBox.Model = listStore;
        }
    }
}
