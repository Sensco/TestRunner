using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    public class WaveTable : DataTable
    {
        const string Name = "waves";

        public WaveTable()
        {
            this.Columns.Add(new DataColumn() { AutoIncrement = true, ColumnName = "Id", DataType = typeof(int), Unique = true });
            this.Columns.Add(new DataColumn() { ColumnName = "Timestamp", DataType = typeof(double) });
            this.Columns.Add(new DataColumn() { ColumnName = "Amplitude", DataType = typeof(byte) });
            this.TableName = WaveTable.Name;
        }
    }
}
