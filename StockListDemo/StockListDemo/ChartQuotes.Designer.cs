namespace DotNetStockListDemo
{
    partial class ChartQuotes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartQuotes));
            this.chartQ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartQ)).BeginInit();
            this.SuspendLayout();
            // 
            // chartQ
            // 
            this.chartQ.BackColor = System.Drawing.SystemColors.Info;
            chartArea1.Name = "ChartArea1";
            this.chartQ.ChartAreas.Add(chartArea1);
            this.chartQ.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartQ.Legends.Add(legend1);
            this.chartQ.Location = new System.Drawing.Point(0, 0);
            this.chartQ.Name = "chartQ";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartQ.Series.Add(series1);
            this.chartQ.Size = new System.Drawing.Size(1107, 592);
            this.chartQ.TabIndex = 0;
            this.chartQ.Text = "chart1";
            // 
            // ChartQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 592);
            this.Controls.Add(this.chartQ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartQuotes";
            this.Text = "Lightstreamer .NET Client Demo - Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartQuotes_FormClosing);
            this.Load += new System.EventHandler(this.ChartQuotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartQ;
    }
}