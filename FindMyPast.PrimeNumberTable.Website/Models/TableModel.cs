using System.Collections.Generic;
using System.Security.Cryptography;

namespace FindMyPast.PrimeNumberTable.Website.Models
{
    public class TableModel
    {
        public List<List<string>> Rows { get; }

        public TableModel()
        {
            Rows = new List<List<string>>();
        }

        public static TableModel From(List<List<int>> table)
        {
            var tableModel = new TableModel();

            foreach (var row in table)
            {
                var modelRow = new List<string>();
                foreach (var value in row)
                {
                    modelRow.Add(SanitisedValue(value));
                }
                tableModel.Rows.Add(modelRow);
            }

            return tableModel;
        }

        private static string SanitisedValue(int value)
        {
            return value == 0 ? string.Empty : value.ToString();
        }
    }
}