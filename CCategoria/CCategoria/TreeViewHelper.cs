using Gtk;
using System;
using System.Data;

namespace CCategoria
{
    public class TreeViewHelper
    {
        public static void Fill(TreeView treeView, string selectSql) {
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
