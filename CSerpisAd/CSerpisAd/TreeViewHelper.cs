using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
    public class TreeViewHelper
    {
        private static void Init(TreeView treeView, IDataReader dataReader)
        {
            if (treeView.Model != null)
                return;

            Type[] types = new Type[dataReader.FieldCount];

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                treeView.AppendColumn(dataReader.GetName(i),
                                      new CellRendererText(),
                                      "text", i);
                types[i] = typeof(string);
            }

            ListStore listStore = new ListStore(types);
            treeView.Model = listStore;
        }

        private static void FillListStore(ListStore listStore,
                                          IDataReader dataReader) {
            listStore.Clear();
            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                    row[i] = dataReader.GetValue(i).ToString();

                listStore.AppendValues(row);
            }
        }

        public static void Fill(TreeView treeView, string selectSql)
        {
            IDataReader dataReader;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            ListStore listStore;

            dbCommand.CommandText = selectSql;
            dataReader = dbCommand.ExecuteReader();
            Init(treeView, dataReader);
            listStore = (ListStore)treeView.Model;
            FillListStore(listStore, dataReader);
            dataReader.Close();
        }

        public static object GetId(TreeView treeView) {
            treeView.Selection.GetSelected(out TreeIter treeIter);
            return treeView.Model.GetValue(treeIter, 0);
        }
    }
}
