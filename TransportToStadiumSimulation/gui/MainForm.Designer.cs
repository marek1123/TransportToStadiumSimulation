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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridMicrobuses = new System.Windows.Forms.DataGridView();
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
            this.checkBoxWaitingOnBusStop = new System.Windows.Forms.CheckBox();
            this.numLineAMicrobuses = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numLineBMicrobuses = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numLineCMicrobuses = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.startTimesLineABuses = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.startTimesBBuses = new System.Windows.Forms.TextBox();
            this.startTimesCBuses = new System.Windows.Forms.TextBox();
            this.startTimesAMicrobuses = new System.Windows.Forms.TextBox();
            this.startTimesBMicrobuses = new System.Windows.Forms.TextBox();
            this.startTimesCMicrobuses = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labelAveragePassengerWaitingTimeRep = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelAveragePassengerWaitingTimeSim = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVehicles)).BeginInit();
            this.tabEntitiesLists.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBusStops)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMicrobuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineAMicrobuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineBMicrobuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineCMicrobuses)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridVehicles);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1504, 261);
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
            this.dataGridVehicles.Size = new System.Drawing.Size(1502, 249);
            this.dataGridVehicles.TabIndex = 0;
            // 
            // tabEntitiesLists
            // 
            this.tabEntitiesLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEntitiesLists.Controls.Add(this.tabPage1);
            this.tabEntitiesLists.Controls.Add(this.tabPage2);
            this.tabEntitiesLists.Controls.Add(this.tabPage3);
            this.tabEntitiesLists.Location = new System.Drawing.Point(12, 301);
            this.tabEntitiesLists.Name = "tabEntitiesLists";
            this.tabEntitiesLists.SelectedIndex = 0;
            this.tabEntitiesLists.Size = new System.Drawing.Size(1512, 290);
            this.tabEntitiesLists.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridBusStops);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1317, 287);
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
            this.dataGridBusStops.Size = new System.Drawing.Size(589, 277);
            this.dataGridBusStops.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridMicrobuses);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1317, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Microbuses";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridMicrobuses
            // 
            this.dataGridMicrobuses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMicrobuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMicrobuses.Location = new System.Drawing.Point(6, 6);
            this.dataGridMicrobuses.Name = "dataGridMicrobuses";
            this.dataGridMicrobuses.RowTemplate.Height = 24;
            this.dataGridMicrobuses.Size = new System.Drawing.Size(589, 277);
            this.dataGridMicrobuses.TabIndex = 1;
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
            this.label13.Location = new System.Drawing.Point(327, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "line A vehicles:";
            // 
            // textBoxLineAVehicles
            // 
            this.textBoxLineAVehicles.Location = new System.Drawing.Point(437, 94);
            this.textBoxLineAVehicles.Name = "textBoxLineAVehicles";
            this.textBoxLineAVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineAVehicles.TabIndex = 28;
            this.textBoxLineAVehicles.TextChanged += new System.EventHandler(this.textBoxLineAVehicles_TextChanged);
            // 
            // textBoxLineBVehicles
            // 
            this.textBoxLineBVehicles.Location = new System.Drawing.Point(437, 121);
            this.textBoxLineBVehicles.Name = "textBoxLineBVehicles";
            this.textBoxLineBVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineBVehicles.TabIndex = 30;
            this.textBoxLineBVehicles.TextChanged += new System.EventHandler(this.textBoxLineBVehicles_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(327, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "line B vehicles:";
            // 
            // textBoxLineCVehicles
            // 
            this.textBoxLineCVehicles.Location = new System.Drawing.Point(437, 149);
            this.textBoxLineCVehicles.Name = "textBoxLineCVehicles";
            this.textBoxLineCVehicles.Size = new System.Drawing.Size(157, 22);
            this.textBoxLineCVehicles.TabIndex = 32;
            this.textBoxLineCVehicles.TextChanged += new System.EventHandler(this.textBoxLineCVehicles_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(327, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "line C vehicles:";
            // 
            // checkBoxWaitingOnBusStop
            // 
            this.checkBoxWaitingOnBusStop.AutoSize = true;
            this.checkBoxWaitingOnBusStop.Location = new System.Drawing.Point(145, 209);
            this.checkBoxWaitingOnBusStop.Name = "checkBoxWaitingOnBusStop";
            this.checkBoxWaitingOnBusStop.Size = new System.Drawing.Size(128, 21);
            this.checkBoxWaitingOnBusStop.TabIndex = 36;
            this.checkBoxWaitingOnBusStop.Text = "wait at bus stop";
            this.checkBoxWaitingOnBusStop.UseVisualStyleBackColor = true;
            this.checkBoxWaitingOnBusStop.CheckedChanged += new System.EventHandler(this.checkBoxWaitingOnBusStop_CheckedChanged);
            // 
            // numLineAMicrobuses
            // 
            this.numLineAMicrobuses.Location = new System.Drawing.Point(456, 186);
            this.numLineAMicrobuses.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLineAMicrobuses.Name = "numLineAMicrobuses";
            this.numLineAMicrobuses.Size = new System.Drawing.Size(120, 22);
            this.numLineAMicrobuses.TabIndex = 38;
            this.numLineAMicrobuses.ValueChanged += new System.EventHandler(this.numLineAMicrobuses_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "line A microbuses:";
            // 
            // numLineBMicrobuses
            // 
            this.numLineBMicrobuses.Location = new System.Drawing.Point(456, 220);
            this.numLineBMicrobuses.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLineBMicrobuses.Name = "numLineBMicrobuses";
            this.numLineBMicrobuses.Size = new System.Drawing.Size(120, 22);
            this.numLineBMicrobuses.TabIndex = 40;
            this.numLineBMicrobuses.ValueChanged += new System.EventHandler(this.numLineBMicrobuses_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "line B microbuses:";
            // 
            // numLineCMicrobuses
            // 
            this.numLineCMicrobuses.Location = new System.Drawing.Point(456, 252);
            this.numLineCMicrobuses.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numLineCMicrobuses.Name = "numLineCMicrobuses";
            this.numLineCMicrobuses.Size = new System.Drawing.Size(120, 22);
            this.numLineCMicrobuses.TabIndex = 42;
            this.numLineCMicrobuses.ValueChanged += new System.EventHandler(this.numLineCMicrobuses_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "line C microbuses:";
            // 
            // startTimesLineABuses
            // 
            this.startTimesLineABuses.Location = new System.Drawing.Point(618, 93);
            this.startTimesLineABuses.Name = "startTimesLineABuses";
            this.startTimesLineABuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesLineABuses.TabIndex = 44;
            this.startTimesLineABuses.TextChanged += new System.EventHandler(this.startTimesLineABuses_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(615, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 17);
            this.label16.TabIndex = 43;
            this.label16.Text = "start times:";
            // 
            // startTimesBBuses
            // 
            this.startTimesBBuses.Location = new System.Drawing.Point(618, 122);
            this.startTimesBBuses.Name = "startTimesBBuses";
            this.startTimesBBuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesBBuses.TabIndex = 45;
            this.startTimesBBuses.TextChanged += new System.EventHandler(this.startTimesBBuses_TextChanged);
            // 
            // startTimesCBuses
            // 
            this.startTimesCBuses.Location = new System.Drawing.Point(618, 151);
            this.startTimesCBuses.Name = "startTimesCBuses";
            this.startTimesCBuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesCBuses.TabIndex = 46;
            this.startTimesCBuses.TextChanged += new System.EventHandler(this.startTimesCBuses_TextChanged);
            // 
            // startTimesAMicrobuses
            // 
            this.startTimesAMicrobuses.Location = new System.Drawing.Point(618, 185);
            this.startTimesAMicrobuses.Name = "startTimesAMicrobuses";
            this.startTimesAMicrobuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesAMicrobuses.TabIndex = 47;
            this.startTimesAMicrobuses.TextChanged += new System.EventHandler(this.startTimesAMicrobuses_TextChanged);
            // 
            // startTimesBMicrobuses
            // 
            this.startTimesBMicrobuses.Location = new System.Drawing.Point(618, 220);
            this.startTimesBMicrobuses.Name = "startTimesBMicrobuses";
            this.startTimesBMicrobuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesBMicrobuses.TabIndex = 48;
            this.startTimesBMicrobuses.TextChanged += new System.EventHandler(this.startTimesBMicrobuses_TextChanged);
            // 
            // startTimesCMicrobuses
            // 
            this.startTimesCMicrobuses.Location = new System.Drawing.Point(618, 252);
            this.startTimesCMicrobuses.Name = "startTimesCMicrobuses";
            this.startTimesCMicrobuses.Size = new System.Drawing.Size(157, 22);
            this.startTimesCMicrobuses.TabIndex = 49;
            this.startTimesCMicrobuses.TextChanged += new System.EventHandler(this.startTimesCMicrobuses_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1056, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(142, 17);
            this.label17.TabIndex = 50;
            this.label17.Text = "replications statistics:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(829, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(212, 17);
            this.label18.TabIndex = 51;
            this.label18.Text = "average passenger waiting time:";
            // 
            // labelAveragePassengerWaitingTimeRep
            // 
            this.labelAveragePassengerWaitingTimeRep.AutoSize = true;
            this.labelAveragePassengerWaitingTimeRep.Location = new System.Drawing.Point(1056, 99);
            this.labelAveragePassengerWaitingTimeRep.Name = "labelAveragePassengerWaitingTimeRep";
            this.labelAveragePassengerWaitingTimeRep.Size = new System.Drawing.Size(0, 17);
            this.labelAveragePassengerWaitingTimeRep.TabIndex = 52;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1293, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 17);
            this.label19.TabIndex = 53;
            this.label19.Text = "simulation statistics:";
            // 
            // labelAveragePassengerWaitingTimeSim
            // 
            this.labelAveragePassengerWaitingTimeSim.AutoSize = true;
            this.labelAveragePassengerWaitingTimeSim.Location = new System.Drawing.Point(1293, 99);
            this.labelAveragePassengerWaitingTimeSim.Name = "labelAveragePassengerWaitingTimeSim";
            this.labelAveragePassengerWaitingTimeSim.Size = new System.Drawing.Size(0, 17);
            this.labelAveragePassengerWaitingTimeSim.TabIndex = 54;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 603);
            this.Controls.Add(this.labelAveragePassengerWaitingTimeSim);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelAveragePassengerWaitingTimeRep);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.startTimesCMicrobuses);
            this.Controls.Add(this.startTimesBMicrobuses);
            this.Controls.Add(this.startTimesAMicrobuses);
            this.Controls.Add(this.startTimesCBuses);
            this.Controls.Add(this.startTimesBBuses);
            this.Controls.Add(this.startTimesLineABuses);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numLineCMicrobuses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numLineBMicrobuses);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numLineAMicrobuses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxWaitingOnBusStop);
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
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMicrobuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineAMicrobuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineBMicrobuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineCMicrobuses)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxWaitingOnBusStop;
        private System.Windows.Forms.NumericUpDown numLineAMicrobuses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numLineBMicrobuses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numLineCMicrobuses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridMicrobuses;
        private System.Windows.Forms.TextBox startTimesLineABuses;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox startTimesBBuses;
        private System.Windows.Forms.TextBox startTimesCBuses;
        private System.Windows.Forms.TextBox startTimesAMicrobuses;
        private System.Windows.Forms.TextBox startTimesBMicrobuses;
        private System.Windows.Forms.TextBox startTimesCMicrobuses;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelAveragePassengerWaitingTimeRep;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelAveragePassengerWaitingTimeSim;
    }
}