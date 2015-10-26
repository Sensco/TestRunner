using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    public class RecordedDataSet : System.Data.DataSet
    {
        public DataTable WaveTable { get; private set; }
        public DataTable EventTable { get; private set; }

        public RecordedDataSet()
        {
            this.WaveTable = new WaveTable();
            this.EventTable = new EventTable();

            this.Tables.Add(this.WaveTable);
            this.Tables.Add(this.EventTable);
        }
    }
}
