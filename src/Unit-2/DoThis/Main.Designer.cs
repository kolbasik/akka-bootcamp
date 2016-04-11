namespace ChartApp
{
    partial class Main
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sysChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DiskButton = new System.Windows.Forms.Button();
            this.MemoryButton = new System.Windows.Forms.Button();
            this.CpuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sysChart
            // 
            chartArea3.Name = "ChartArea1";
            this.sysChart.ChartAreas.Add(chartArea3);
            this.sysChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.sysChart.Legends.Add(legend3);
            this.sysChart.Location = new System.Drawing.Point(0, 0);
            this.sysChart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sysChart.Name = "sysChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.sysChart.Series.Add(series3);
            this.sysChart.Size = new System.Drawing.Size(1368, 858);
            this.sysChart.TabIndex = 0;
            this.sysChart.Text = "sysChart";
            // 
            // DiskButton
            // 
            this.DiskButton.Location = new System.Drawing.Point(1121, 770);
            this.DiskButton.Name = "DiskButton";
            this.DiskButton.Size = new System.Drawing.Size(235, 72);
            this.DiskButton.TabIndex = 1;
            this.DiskButton.Text = "DISK (OFF)";
            this.DiskButton.UseVisualStyleBackColor = true;
            this.DiskButton.Click += new System.EventHandler(this.DiskButton_Click);
            // 
            // MemoryButton
            // 
            this.MemoryButton.Location = new System.Drawing.Point(1121, 679);
            this.MemoryButton.Name = "MemoryButton";
            this.MemoryButton.Size = new System.Drawing.Size(235, 72);
            this.MemoryButton.TabIndex = 2;
            this.MemoryButton.Text = "MEMORY (OFF)";
            this.MemoryButton.UseVisualStyleBackColor = true;
            this.MemoryButton.Click += new System.EventHandler(this.MemoryButton_Click);
            // 
            // CpuButton
            // 
            this.CpuButton.Location = new System.Drawing.Point(1121, 588);
            this.CpuButton.Name = "CpuButton";
            this.CpuButton.Size = new System.Drawing.Size(235, 72);
            this.CpuButton.TabIndex = 3;
            this.CpuButton.Text = "CPU (ON)";
            this.CpuButton.UseVisualStyleBackColor = true;
            this.CpuButton.Click += new System.EventHandler(this.CpuButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 858);
            this.Controls.Add(this.CpuButton);
            this.Controls.Add(this.MemoryButton);
            this.Controls.Add(this.DiskButton);
            this.Controls.Add(this.sysChart);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Main";
            this.Text = "System Metrics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sysChart;
        private System.Windows.Forms.Button DiskButton;
        private System.Windows.Forms.Button MemoryButton;
        private System.Windows.Forms.Button CpuButton;
    }
}

