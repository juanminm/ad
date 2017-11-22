using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
    public class ComboBoxHelper
    {
        private static void Init(ComboBox comboBox, IDataReader dataReader)
        {
            if (comboBox.Model != null)
                return;

            Type[] types = new Type[dataReader.FieldCount];

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                types[i] = typeof(string);
            }

            CellRendererText nombreCellRendererText = new CellRendererText();
            comboBox.PackStart(nombreCellRendererText, false);
            comboBox.AddAttribute(nombreCellRendererText, "text", 1);

            ListStore listStore = new ListStore(types);
            comboBox.Model = listStore;
        }

        private static void FillListStore(ComboBox comboBox,
                                          IDataReader dataReader, object id,
                                          Boolean withNull)
        {
            ListStore listStore = (ListStore)comboBox.Model;
            TreeIter treeIter = new TreeIter();

            while (dataReader.Read())
            {
                object[] row = new object[dataReader.FieldCount];

                for (int i = 0; i < row.Length; i++)
                {
                    row[i] = dataReader.GetValue(i).ToString();

                    if (!withNull && i == 0 && id.Equals(dataReader[0]))
                        listStore.IterNthChild(out treeIter, i);
                }

                listStore.AppendValues(row);
            }


            if (withNull)
            {
                listStore.Insert(0);
                listStore.GetIterFirst(out treeIter);
                comboBox.SetActiveIter(treeIter);
            }
            else
            {
                comboBox.SetActiveIter(treeIter);
            }
        }

        public static void Fill(ComboBox comboBox, String sqlString, object id,
                               Boolean withNull)
        {
            IDataReader dataReader;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();

            dbCommand.CommandText = sqlString;
            dataReader = dbCommand.ExecuteReader();

            Init(comboBox, dataReader);
            FillListStore(comboBox, dataReader, id, withNull);

            dataReader.Close();
        }
    }
}
