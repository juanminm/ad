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

        private static void FillListStore(ListStore listStore,
                                        IDataReader dataReader)
        {
            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                    row[i] = dataReader.GetValue(i).ToString();

                listStore.AppendValues(row);
            }
        }

        public static void Fill(ComboBox comboBox, String sqlString)
        {
            IDataReader dataReader;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            ListStore listStore;

            dbCommand.CommandText = sqlString;
            dataReader = dbCommand.ExecuteReader();

            Init(comboBox);
            listStore = (ListStore)comboBox.Model;
            FillListStore(listStore, dataReader);

            dataReader.Close();
        }
    }
}
