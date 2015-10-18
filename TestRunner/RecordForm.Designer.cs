namespace TestRunner
{
    partial class RecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTimer = new System.Windows.Forms.Label();
            this.listEvents = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.visualizer = new TestRunner.Controls.VisualizerControl();
            this.buttonPause = new TestRunner.Controls.PauseButton();
            this.buttonStart = new TestRunner.Controls.RecordButton();
            this.buttonStop = new TestRunner.Controls.StopButton();
            this.buttonNewEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(21, 71);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(212, 55);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "00:00:00";
            // 
            // listEvents
            // 
            this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listEvents.Location = new System.Drawing.Point(10, 210);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(237, 246);
            this.listEvents.TabIndex = 5;
            this.listEvents.UseCompatibleStateImageBehavior = false;
            this.listEvents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 30;
            this.columnHeader2.Width = 60;
            // 
            // visualizer
            // 
            this.visualizer.AutoSize = true;
            this.visualizer.Location = new System.Drawing.Point(12, 9);
            this.visualizer.Name = "visualizer";
            this.visualizer.Size = new System.Drawing.Size(0, 13);
            this.visualizer.TabIndex = 4;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(183, 141);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(45, 45);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(102, 141);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(45, 45);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(21, 141);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(45, 45);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonNewEvent
            // 
            this.buttonNewEvent.Location = new System.Drawing.Point(172, 462);
            this.buttonNewEvent.Name = "buttonNewEvent";
            this.buttonNewEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonNewEvent.TabIndex = 6;
            this.buttonNewEvent.Text = "New Event";
            this.buttonNewEvent.UseVisualStyleBackColor = true;
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 496);
            this.Controls.Add(this.buttonNewEvent);
            this.Controls.Add(this.listEvents);
            this.Controls.Add(this.visualizer);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Name = "RecordForm";
            this.Text = "Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTimer;
        private Controls.VisualizerControl visualizer;
        private System.Windows.Forms.ListView listEvents;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Controls.StopButton buttonStop;
        private Controls.RecordButton buttonStart;
        private Controls.PauseButton buttonPause;
        private System.Windows.Forms.Button buttonNewEvent;
    }
}

