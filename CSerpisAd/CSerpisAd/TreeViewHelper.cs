using Gtk;
using System;
using System.Data;
using GLib;

namespace Serpis.Ad
{
    public class TreeViewHelper
    {
        public static void SetListStore(TreeView treeView,
                                        params string[] rowNames)
        {
            GType[] types = new GType[rowNames.Length];
            ListStore listStore;

            for (int i = 0; i < rowNames.Length; i++)
            {
                treeView.AppendColumn(rowNames[i], new CellRendererText(),
                                      "text", i);
                types[i] = (GType)typeof(string);
            }
            
            listStore = new ListStore(types);
            treeView.Model = listStore;
        }

        public static void Fill(TreeView treeView, string selectSql)
        {
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            IDataReader dataReader;

            dbCommand.CommandText = selectSql;
            dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                {
                    row[i] = dataReader.GetValue(i).ToString();
                }

                ((ListStore)treeView.Model).AppendValues(row);
            }
            dataReader.Close();
        }
    }
}
