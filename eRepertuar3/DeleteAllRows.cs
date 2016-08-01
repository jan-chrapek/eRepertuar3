using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MyNameSpace
{
    static class DeleteAllRowsFromDataSetOrTable
    {
        public static void DeleteAllRows(this DataTable table)
        {
            int idx = 0;
            while (idx < table.Rows.Count)
            {
                int curCount = table.Rows.Count;
                table.Rows[idx].Delete();
                if (curCount == table.Rows.Count) idx++;
            }
        }
        public static void DeleteAllRows(this DataSet dataSet)
        {
            foreach (DataTable dt in dataSet.Tables)
            {
                dt.DeleteAllRows();
            }
        }
    }
}
