using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRunner
{
    public partial class RecordForm : Form
    {
        protected Timer timer = new Timer();
        protected TimeSpan timespan = new TimeSpan();
        protected DateTime lastTick;
        protected WaveIn waveIn;
        protected WaveFormat waveFormat;
        protected string testName = string.Format(".\\{0}", DateTime.Now.ToFileTime());

        public RecordForm()
        {
            InitializeComponent();

            this.timer.Tick += Timer_Tick;
            this.timer.Interval = 100;

            this.buttonPause.Click += ButtonPause_Click;
            this.buttonStop.Click += ButtonStop_Click;
            this.buttonStart.Click += ButtonStart_Click;
            this.buttonNewEvent.Click += ButtonNewEvent_Click;

            this.buttonPause.Enabled = false;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
            this.buttonClear.Enabled = false;
            this.buttonSave.Enabled = false;

            this.waveIn = new WaveIn();
            this.waveFormat = new WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(this.waveIn.DeviceNumber).Channels);
            this.waveIn.WaveFormat = this.waveFormat;
            this.waveIn.DataAvailable += WaveIn_DataAvailable;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - this.lastTick;
            this.timespan = this.timespan.Add(elapsed);
            this.lastTick = DateTime.Now;
            this.labelTimer.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }

        private void AddEvent(string text)
        {
            DataRow row = this.dataSet.EventTable.NewRow();

            row["Timestamp"] = Math.Round(this.timespan.TotalMilliseconds);
            row["Description"] = text;

            this.dataSet.EventTable.Rows.Add(row);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            foreach(byte b in e.Buffer)
            {
                DataRow row = this.dataSet.WaveTable.NewRow();

                row["Timestamp"] = Math.Round(this.timespan.TotalMilliseconds);
                row["Amplitude"] = b;

                this.dataSet.WaveTable.Rows.Add(row);
            }
        }

        private void ButtonNewEvent_Click(object sender, EventArgs e)
        {
            AddEvent("New event");
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            this.AddEvent("Recording paused");

            this.waveIn.StopRecording();
            this.timer.Stop();
            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = true;
            this.buttonNewEvent.Enabled = true;
            this.buttonClear.Enabled = false;
            this.buttonSave.Enabled = false;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            this.AddEvent("Recording stopped");

            this.waveIn.StopRecording();
            this.timer.Stop();
            this.timespan = new TimeSpan();
            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
            this.buttonClear.Enabled = true;
            this.buttonSave.Enabled = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.AddEvent("Recording started");
            this.waveIn.StartRecording();

            this.lastTick = DateTime.Now;
            this.timer.Start();
            this.buttonPause.Enabled = true;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;
            this.buttonNewEvent.Enabled = true;
            this.buttonClear.Enabled = false;
            this.buttonSave.Enabled = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
            this.buttonClear.Enabled = false;
            this.buttonSave.Enabled = false;

            WaveFileWriter writer = new WaveFileWriter(this.testName + ".wav", this.waveFormat);
            foreach(DataRow row in dataSet.WaveTable.Rows)
            {
                writer.WriteByte((byte)row["Amplitude"]);
            }
            writer.Close();

            var result = new StringBuilder();
            for (int i = 0; i < dataSet.WaveTable.Columns.Count; i++)
            {
                result.Append(dataSet.WaveTable.Columns[i].ColumnName);
                result.Append(i == dataSet.WaveTable.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in dataSet.WaveTable.Rows)
            {
                for (int i = 0; i < dataSet.WaveTable.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == dataSet.WaveTable.Columns.Count - 1 ? "\n" : ",");
                }
            }

            StreamWriter waveData = System.IO.File.CreateText(this.testName + "-wave.csv");
            waveData.Write(result.ToString());
            waveData.Close();

            result = new StringBuilder();
            for (int i = 0; i < dataSet.EventTable.Columns.Count; i++)
            {
                result.Append(dataSet.EventTable.Columns[i].ColumnName);
                result.Append(i == dataSet.EventTable.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in dataSet.EventTable.Rows)
            {
                for (int i = 0; i < dataSet.EventTable.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == dataSet.EventTable.Columns.Count - 1 ? "\n" : ",");
                }
            }

            StreamWriter eventData = System.IO.File.CreateText(this.testName + "-event.csv");
            eventData.Write(result.ToString());
            eventData.Close();

            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
            this.buttonClear.Enabled = true;
            this.buttonSave.Enabled = false;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.testName = string.Format(".\\{0}", DateTime.Now.ToFileTime());
            this.dataSet.Clear();
        }
    }
}
