using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
    public class TreeViewHelper
    {
        public static void Fill(TreeView treeView, string selectSql)
        {
            IDataReader dataReader;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            ListStore listStore = (ListStore)treeView.Model;

            dbCommand.CommandText = selectSql;
            dataReader = dbCommand.ExecuteReader();

            if (listStore == null)
            {
                Type[] types = new Type[dataReader.FieldCount];

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    treeView.AppendColumn(dataReader.GetName(i),
                                          new CellRendererText(),
                                          "text", i);
                    types[i] = typeof(string);
                }

                listStore = new ListStore(types);
                treeView.Model = listStore;
            }
            else
            {
                listStore.Clear();
            }

            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                    row[i] = dataReader.GetValue(i).ToString();

                listStore.AppendValues(row);
            }

            dataReader.Close();
        }
    }
}
