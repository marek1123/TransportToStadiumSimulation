namespace TransportToStadiumAgentSimulation.gui
{
    partial class MainForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridVehicles = new System.Windows.Forms.DataGridView();
            this.tabEntitiesLists = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridBusStops = new System.Windows.Forms.DataGridView();
            this.buttStart = new System.Windows.Forms.Button();
            this.buttStop = new System.Windows.Forms.Button();
            this.buttPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numReplicationsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.trackBarDuration = new System.Windows.Forms.TrackBar();
            this.trackBarInterval = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxFastMode = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelReplication = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLineAVehicles = new System.Windows.Forms.TextBox();
            this.textBoxLineBVehicles = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxLineCVehicles = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labelLineAVehicles = new System.Windows.Forms.Label();
            this.labelLineCVehicles = new System.Windows.Forms.Label();
            this.labelLineBVehicles = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVehicles)).BeginInit();
            this.tabEntitiesLists.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusStops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridVehicles);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(601, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AllVehicles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridVehicles
            // 
            this.dataGridVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVehicles.Location = new System.Drawing.Point(6, 6);
            this.dataGridVehicles.Name = "dataGridVehicles";
            this.dataGridVehicles.RowTemplate.Height = 24;
            this.dataGridVehicles.Size = new System.Drawing.Size(599, 274);
            this.dataGridVehicles.TabIndex = 0;
            // 
            // tabEntitiesLists
            // 
            this.tabEntitiesLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEntitiesLists.Controls.Add(this.tabPage1);
            this.tabEntitiesLists.Controls.Add(this.tabPage2);
            this.tabEntitiesLists.Location = new System.Drawing.Point(12, 248);
            this.tabEntitiesLists.Name = "tabEntitiesLists";
            this.tabEntitiesLists.SelectedIndex = 0;
            this.tabEntitiesLists.Size = new System.Drawing.Size(609, 315);
            this.tabEntitiesLists.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridBusStops);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bus stops";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridBusStops
            // 
            this.dataGridBusStops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridBusStops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBusStops.Location = new System.Drawing.Point(6, 6);
            this.dataGridBusStops.Name = "dataGridBusStops";
            this.dataGridBusStops.RowTemplate.Height = 24;
            this.dataGridBusStops.Size = new System.Drawing.Size(756, 277);
            this.dataGridBusStops.TabIndex = 0;
            // 
            // buttStart
            // 
            this.buttStart.Location = new System.Drawing.Point(19, 26);
            this.buttStart.Name = "buttStart";
            this.buttStart.Size = new System.Drawing.Size(75, 23);
            this.buttStart.TabIndex = 1;
            this.buttStart.Text = "Start";
            this.buttStart.UseVisualStyleBackColor = true;
            this.buttStart.Click += new System.EventHandler(this.buttStart_Click);
            // 
            // buttStop
            // 
            this.buttStop.Location = new System.Drawing.Point(198, 26);
            this.buttStop.Name = "buttStop";
            this.buttStop.Size = new System.Drawing.Size(75, 23);
            this.buttStop.TabIndex = 2;
            this.buttStop.Text = "Stop";
            this.buttStop.UseVisualStyleBackColor = true;
            this.buttStop.Click += new System.EventHandler(this.buttStop_Click);
            // 
            // buttPause
            // 
            this.buttPause.Location = new System.Drawing.Point(100, 26);
            this.buttPause.Name = "buttPause";
            this.buttPause.Size = new System.Drawing.Size(92, 23);
            this.buttPause.TabIndex = 3;
            this.buttPause.Text = "Pause";
            this.buttPause.UseVisualStyleBackColor = true;
            this.buttPause.Click += new System.EventHandler(this.buttPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "replications count:";
            // 
            // numReplicationsCount
            // 
            this.numReplicationsCount.Location = new System.Drawing.Point(145, 63);
            this.numReplicationsCount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numReplicationsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReplicationsCount.Name = "numReplicationsCount";
            this.numReplicationsCount.Size = new System.Drawing.Size(120, 22);
            this.numReplicationsCount.TabIndex = 5;
            this.numReplicationsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "duration (ms):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "interval (s):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "time:";
            // 
            // labelTime
            // 
            this.labelTime.Location = new System.Drawing.Point(603, 32);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(123, 17);
            this.labelTime.TabIndex = 17;
            // 
            // trackBarDuration
            // 
            this.trackBarDuration.Location = new System.Drawing.Point(118, 94);
            this.trackBarDuration.Maximum = 1000;
            this.trackBarDuration.Name = "trackBarDuration";
            this.trackBarDuration.Size = new System.Drawing.Size(123, 56);
            this.trackBarDuration.TabIndex = 18;
            this.trackBarDuration.TickFrequency = 100;
            this.trackBarDuration.Value = 1000;
            this.trackBarDuration.ValueChanged += new System.EventHandler(this.trackBarDuration_ValueChanged);
            // 
            // trackBarInterval
            // 
            this.trackBarInterval.Location = new System.Drawing.Point(118, 147);
            this.trackBarInterval.Maximum = 600;
            this.trackBarInterval.Minimum = 1;
            this.trackBarInterval.Name = "trackBarInterval";
            this.trackBarInterval.Size = new System.Drawing.Size(123, 56);
            this.trackBarInterval.TabIndex = 19;
            this.trackBarInterval.TickFrequency = 50;
            this.trackBarInterval.Value = 1;
            this.trackBarInterval.ValueChanged += new System.EventHandler(this.trackBarInterval_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "600";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "1000";
            // 
            // checkBoxFastMode
            // 
            this.checkBoxFastMode.AutoSize = true;
            this.checkBoxFastMode.Location = new System.Drawing.Point(19, 209);
            this.checkBoxFastMode.Name = "checkBoxFastMode";
            this.checkBoxFastMode.Size = new System.Drawing.Size(92, 21);
            this.checkBoxFastMode.TabIndex = 24;
            this.checkBoxFastMode.Text = "fast mode";
            this.checkBoxFastMode.UseVisualStyleBackColor = true;
            this.checkBoxFastMode.CheckedChanged += new System.EventHandler(this.checkBoxFastMode_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 17);
            this.label12.TabIndex = 25;
            this.label12.Text = "replication:";
            // 
            // labelReplication
            // 
            this.labelReplication.Location = new System.Drawing.Point(410, 32);
            this.labelReplication.Name = "labelReplication";
            this.labelReplication.Size = new System.Drawing.Size(127, 17);
            this.labelReplication.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(327, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "line A vehicles:";
            // 
            // textBoxLineAVehicles
            // 
            this.textBoxLineAVehicles.Location = new System.Drawing.Point(437, 68);
            this.textBoxLineAVehicles.Name = "textBoxLineAVehicles";
            this.textBoxLineAVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineAVehicles.TabIndex = 28;
            this.textBoxLineAVehicles.TextChanged += new System.EventHandler(this.textBoxLineAVehicles_TextChanged);
            // 
            // textBoxLineBVehicles
            // 
            this.textBoxLineBVehicles.Location = new System.Drawing.Point(437, 95);
            this.textBoxLineBVehicles.Name = "textBoxLineBVehicles";
            this.textBoxLineBVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineBVehicles.TabIndex = 30;
            this.textBoxLineBVehicles.TextChanged += new System.EventHandler(this.textBoxLineBVehicles_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(327, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "line B vehicles:";
            // 
            // textBoxLineCVehicles
            // 
            this.textBoxLineCVehicles.Location = new System.Drawing.Point(437, 123);
            this.textBoxLineCVehicles.Name = "textBoxLineCVehicles";
            this.textBoxLineCVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineCVehicles.TabIndex = 32;
            this.textBoxLineCVehicles.TextChanged += new System.EventHandler(this.textBoxLineCVehicles_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(327, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "line C vehicles:";
            // 
            // labelLineAVehicles
            // 
            this.labelLineAVehicles.AutoSize = true;
            this.labelLineAVehicles.Location = new System.Drawing.Point(600, 70);
            this.labelLineAVehicles.Name = "labelLineAVehicles";
            this.labelLineAVehicles.Size = new System.Drawing.Size(0, 17);
            this.labelLineAVehicles.TabIndex = 33;
            // 
            // labelLineCVehicles
            // 
            this.labelLineCVehicles.AutoSize = true;
            this.labelLineCVehicles.Location = new System.Drawing.Point(600, 126);
            this.labelLineCVehicles.Name = "labelLineCVehicles";
            this.labelLineCVehicles.Size = new System.Drawing.Size(0, 17);
            this.labelLineCVehicles.TabIndex = 34;
            // 
            // labelLineBVehicles
            // 
            this.labelLineBVehicles.AutoSize = true;
            this.labelLineBVehicles.Location = new System.Drawing.Point(600, 98);
            this.labelLineBVehicles.Name = "labelLineBVehicles";
            this.labelLineBVehicles.Size = new System.Drawing.Size(0, 17);
            this.labelLineBVehicles.TabIndex = 35;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 575);
            this.Controls.Add(this.labelLineBVehicles);
            this.Controls.Add(this.labelLineCVehicles);
            this.Controls.Add(this.labelLineAVehicles);
            this.Controls.Add(this.textBoxLineCVehicles);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxLineBVehicles);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxLineAVehicles);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelReplication);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBoxFastMode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBarInterval);
            this.Controls.Add(this.trackBarDuration);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numReplicationsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttPause);
            this.Controls.Add(this.buttStop);
            this.Controls.Add(this.buttStart);
            this.Controls.Add(this.tabEntitiesLists);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVehicles)).EndInit();
            this.tabEntitiesLists.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusStops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridVehicles;
        private System.Windows.Forms.TabControl tabEntitiesLists;
        private System.Windows.Forms.Button buttStart;
        private System.Windows.Forms.Button buttStop;
        private System.Windows.Forms.Button buttPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numReplicationsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TrackBar trackBarDuration;
        private System.Windows.Forms.TrackBar trackBarInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxFastMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelReplication;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridBusStops;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLineAVehicles;
        private System.Windows.Forms.TextBox textBoxLineBVehicles;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxLineCVehicles;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelLineAVehicles;
        private System.Windows.Forms.Label labelLineCVehicles;
        private System.Windows.Forms.Label labelLineBVehicles;
    }
}