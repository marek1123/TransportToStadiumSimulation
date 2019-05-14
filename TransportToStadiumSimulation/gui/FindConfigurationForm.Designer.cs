namespace TransportToStadiumSimulation.gui
{
    partial class FindConfigurationForm
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
            this.numReplicationsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttStop = new System.Windows.Forms.Button();
            this.buttStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelValidConfigCount = new System.Windows.Forms.Label();
            this.labelTestedConfigCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBestConfiguration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCurrentRep = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelMinCost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMinAverageWaitingTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelMinArrivedAfterStartRatio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // numReplicationsCount
            // 
            this.numReplicationsCount.Location = new System.Drawing.Point(154, 56);
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
            this.numReplicationsCount.TabIndex = 7;
            this.numReplicationsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "replications count:";
            // 
            // buttStop
            // 
            this.buttStop.Location = new System.Drawing.Point(129, 102);
            this.buttStop.Name = "buttStop";
            this.buttStop.Size = new System.Drawing.Size(75, 23);
            this.buttStop.TabIndex = 9;
            this.buttStop.Text = "Stop";
            this.buttStop.UseVisualStyleBackColor = true;
            this.buttStop.Click += new System.EventHandler(this.buttStop_Click);
            // 
            // buttStart
            // 
            this.buttStart.Location = new System.Drawing.Point(31, 102);
            this.buttStart.Name = "buttStart";
            this.buttStart.Size = new System.Drawing.Size(75, 23);
            this.buttStart.TabIndex = 8;
            this.buttStart.Text = "Start";
            this.buttStart.UseVisualStyleBackColor = true;
            this.buttStart.Click += new System.EventHandler(this.buttStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tested configurations count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Valid configurations count:";
            // 
            // labelValidConfigCount
            // 
            this.labelValidConfigCount.AutoSize = true;
            this.labelValidConfigCount.Location = new System.Drawing.Point(230, 188);
            this.labelValidConfigCount.Name = "labelValidConfigCount";
            this.labelValidConfigCount.Size = new System.Drawing.Size(0, 17);
            this.labelValidConfigCount.TabIndex = 12;
            // 
            // labelTestedConfigCount
            // 
            this.labelTestedConfigCount.AutoSize = true;
            this.labelTestedConfigCount.Location = new System.Drawing.Point(230, 154);
            this.labelTestedConfigCount.Name = "labelTestedConfigCount";
            this.labelTestedConfigCount.Size = new System.Drawing.Size(0, 17);
            this.labelTestedConfigCount.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Best configuration:";
            // 
            // labelBestConfiguration
            // 
            this.labelBestConfiguration.AutoSize = true;
            this.labelBestConfiguration.Location = new System.Drawing.Point(230, 224);
            this.labelBestConfiguration.Name = "labelBestConfiguration";
            this.labelBestConfiguration.Size = new System.Drawing.Size(0, 17);
            this.labelBestConfiguration.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "current rep:";
            // 
            // labelCurrentRep
            // 
            this.labelCurrentRep.AutoSize = true;
            this.labelCurrentRep.Location = new System.Drawing.Point(403, 61);
            this.labelCurrentRep.Name = "labelCurrentRep";
            this.labelCurrentRep.Size = new System.Drawing.Size(0, 17);
            this.labelCurrentRep.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Min cost:";
            // 
            // labelMinCost
            // 
            this.labelMinCost.AutoSize = true;
            this.labelMinCost.Location = new System.Drawing.Point(110, 259);
            this.labelMinCost.Name = "labelMinCost";
            this.labelMinCost.Size = new System.Drawing.Size(0, 17);
            this.labelMinCost.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Min average waiting time:";
            // 
            // labelMinAverageWaitingTime
            // 
            this.labelMinAverageWaitingTime.AutoSize = true;
            this.labelMinAverageWaitingTime.Location = new System.Drawing.Point(198, 292);
            this.labelMinAverageWaitingTime.Name = "labelMinAverageWaitingTime";
            this.labelMinAverageWaitingTime.Size = new System.Drawing.Size(0, 17);
            this.labelMinAverageWaitingTime.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Min arrived after start:";
            // 
            // labelMinArrivedAfterStartRatio
            // 
            this.labelMinArrivedAfterStartRatio.AutoSize = true;
            this.labelMinArrivedAfterStartRatio.Location = new System.Drawing.Point(198, 329);
            this.labelMinArrivedAfterStartRatio.Name = "labelMinArrivedAfterStartRatio";
            this.labelMinArrivedAfterStartRatio.Size = new System.Drawing.Size(0, 17);
            this.labelMinArrivedAfterStartRatio.TabIndex = 23;
            // 
            // FindConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelMinArrivedAfterStartRatio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelMinAverageWaitingTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelMinCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelCurrentRep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBestConfiguration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelTestedConfigCount);
            this.Controls.Add(this.labelValidConfigCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttStop);
            this.Controls.Add(this.buttStart);
            this.Controls.Add(this.numReplicationsCount);
            this.Controls.Add(this.label1);
            this.Name = "FindConfigurationForm";
            this.Text = "FindConfigurationForm";
            ((System.ComponentModel.ISupportInitialize)(this.numReplicationsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numReplicationsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttStop;
        private System.Windows.Forms.Button buttStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelValidConfigCount;
        private System.Windows.Forms.Label labelTestedConfigCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBestConfiguration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCurrentRep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelMinCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMinAverageWaitingTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelMinArrivedAfterStartRatio;
    }
}