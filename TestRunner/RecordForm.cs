using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        protected Microphone mic = Microphone.Default;

        public RecordForm()
        {
            InitializeComponent();

            this.columnHeader3.Width = this.listEvents.Width - this.columnHeader2.Width - this.columnHeader1.Width - 4;

            this.timer.Tick += Timer_Tick;
            this.timer.Interval = 100;

            this.buttonPause.Click += ButtonPause_Click;
            this.buttonStop.Click += ButtonStop_Click;
            this.buttonStart.Click += ButtonStart_Click;
            this.buttonNewEvent.Click += ButtonNewEvent_Click;

            this.buttonPause.Enabled = false;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
        }

        private void ButtonNewEvent_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            item.SubItems.Insert(1, new ListViewItem.ListViewSubItem()
            {
                Text = this.labelTimer.Text
            });
            item.SubItems.Insert(2, new ListViewItem.ListViewSubItem()
            {
                Text = "New event"
            });

            listEvents.Items.Add(item);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - this.lastTick;
            this.timespan = this.timespan.Add(elapsed);
            this.lastTick = DateTime.Now;
            this.labelTimer.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = true;
            this.buttonNewEvent.Enabled = false;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.timespan = new TimeSpan();
            this.buttonPause.Enabled = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonNewEvent.Enabled = false;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.lastTick = DateTime.Now;
            this.timer.Start();
            this.buttonPause.Enabled = true;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;
            this.buttonNewEvent.Enabled = true;
        }     
    }
}
