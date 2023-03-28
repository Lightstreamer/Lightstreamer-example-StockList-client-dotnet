#region License
/*
 * Copyright (c) Lightstreamer Srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion License

namespace DotNetStockListDemo {
    partial class DemoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridview = new System.Windows.Forms.DataGridView();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PctChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BidQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AskQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChartBtn = new System.Windows.Forms.DataGridViewImageColumn();
            this.logoImg = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnResetConn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblHigh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 993);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1388, 27);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1366, 21);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "Connecting to Lightstreamer Server...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridview
            // 
            this.dataGridview.AllowUserToAddRows = false;
            this.dataGridview.AllowUserToDeleteRows = false;
            this.dataGridview.AllowUserToOrderColumns = true;
            this.dataGridview.AllowUserToResizeRows = false;
            this.dataGridview.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.dataGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridview.CausesValidation = false;
            this.dataGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockName,
            this.LastPrice,
            this.Time,
            this.PctChange,
            this.BidQuantity,
            this.Bid,
            this.Ask,
            this.AskQuantity,
            this.Min,
            this.Max,
            this.RefPrice,
            this.OpenPrice,
            this.ChartBtn});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridview.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridview.Location = new System.Drawing.Point(0, 238);
            this.dataGridview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridview.Name = "dataGridview";
            this.dataGridview.ReadOnly = true;
            this.dataGridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridview.Size = new System.Drawing.Size(1388, 754);
            this.dataGridview.TabIndex = 3;
            this.dataGridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridview_CellDoubleClick);
            // 
            // StockName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.StockName.DefaultCellStyle = dataGridViewCellStyle2;
            this.StockName.HeaderText = "Name";
            this.StockName.MinimumWidth = 6;
            this.StockName.Name = "StockName";
            this.StockName.ReadOnly = true;
            this.StockName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StockName.ToolTipText = "Double click to open a new chart form";
            this.StockName.Width = 150;
            // 
            // LastPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.LastPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.LastPrice.HeaderText = "Last";
            this.LastPrice.MinimumWidth = 6;
            this.LastPrice.Name = "LastPrice";
            this.LastPrice.ReadOnly = true;
            this.LastPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastPrice.Width = 77;
            // 
            // Time
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "T";
            dataGridViewCellStyle4.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle4;
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 90;
            // 
            // PctChange
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.PctChange.DefaultCellStyle = dataGridViewCellStyle5;
            this.PctChange.HeaderText = "Change %";
            this.PctChange.MinimumWidth = 6;
            this.PctChange.Name = "PctChange";
            this.PctChange.ReadOnly = true;
            this.PctChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PctChange.Width = 89;
            // 
            // BidQuantity
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BidQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.BidQuantity.HeaderText = "Bid Size";
            this.BidQuantity.MinimumWidth = 6;
            this.BidQuantity.Name = "BidQuantity";
            this.BidQuantity.ReadOnly = true;
            this.BidQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BidQuantity.Width = 89;
            // 
            // Bid
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Bid.DefaultCellStyle = dataGridViewCellStyle7;
            this.Bid.HeaderText = "Bid";
            this.Bid.MinimumWidth = 6;
            this.Bid.Name = "Bid";
            this.Bid.ReadOnly = true;
            this.Bid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bid.Width = 60;
            // 
            // Ask
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Ask.DefaultCellStyle = dataGridViewCellStyle8;
            this.Ask.HeaderText = "Ask";
            this.Ask.MinimumWidth = 6;
            this.Ask.Name = "Ask";
            this.Ask.ReadOnly = true;
            this.Ask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ask.Width = 60;
            // 
            // AskQuantity
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AskQuantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.AskQuantity.HeaderText = "Ask Size";
            this.AskQuantity.MinimumWidth = 6;
            this.AskQuantity.Name = "AskQuantity";
            this.AskQuantity.ReadOnly = true;
            this.AskQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AskQuantity.Width = 92;
            // 
            // Min
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Min.DefaultCellStyle = dataGridViewCellStyle10;
            this.Min.HeaderText = "Min";
            this.Min.MinimumWidth = 6;
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            this.Min.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Min.Width = 60;
            // 
            // Max
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.Max.DefaultCellStyle = dataGridViewCellStyle11;
            this.Max.HeaderText = "Max";
            this.Max.MinimumWidth = 6;
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            this.Max.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Max.Width = 60;
            // 
            // RefPrice
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.RefPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.RefPrice.HeaderText = "Ref.";
            this.RefPrice.MinimumWidth = 6;
            this.RefPrice.Name = "RefPrice";
            this.RefPrice.ReadOnly = true;
            this.RefPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RefPrice.Width = 73;
            // 
            // OpenPrice
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.OpenPrice.DefaultCellStyle = dataGridViewCellStyle13;
            this.OpenPrice.HeaderText = "Open";
            this.OpenPrice.MinimumWidth = 6;
            this.OpenPrice.Name = "OpenPrice";
            this.OpenPrice.ReadOnly = true;
            this.OpenPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OpenPrice.Width = 85;
            // 
            // ChartBtn
            // 
            this.ChartBtn.HeaderText = "";
            this.ChartBtn.Image = ((System.Drawing.Image)(resources.GetObject("ChartBtn.Image")));
            this.ChartBtn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ChartBtn.MinimumWidth = 6;
            this.ChartBtn.Name = "ChartBtn";
            this.ChartBtn.ReadOnly = true;
            this.ChartBtn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ChartBtn.ToolTipText = "Double Click to open a Chart Form";
            this.ChartBtn.Width = 25;
            // 
            // logoImg
            // 
            this.logoImg.Image = ((System.Drawing.Image)(resources.GetObject("logoImg.Image")));
            this.logoImg.Location = new System.Drawing.Point(67, 55);
            this.logoImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoImg.Name = "logoImg";
            this.logoImg.Size = new System.Drawing.Size(443, 87);
            this.logoImg.TabIndex = 4;
            this.logoImg.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.title.Location = new System.Drawing.Point(609, 32);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(463, 32);
            this.title.TabIndex = 6;
            this.title.Text = ".NET Framework :: Stock-List Demo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblStatus.CausesValidation = false;
            this.lblStatus.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblStatus.Location = new System.Drawing.Point(1188, 32);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(93, 32);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "label2";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "no - (Stream-Sense Enabled)",
            "WS",
            "HTTP",
            "WS-STREAMING",
            "HTTP-STREAMING",
            "WS-POLLING",
            "HTTP-POLLING"});
            this.comboBox1.Location = new System.Drawing.Point(603, 99);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(445, 32);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnResetConn
            // 
            this.btnResetConn.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnResetConn.FlatAppearance.BorderSize = 0;
            this.btnResetConn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResetConn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResetConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetConn.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResetConn.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnResetConn.Location = new System.Drawing.Point(1085, 100);
            this.btnResetConn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetConn.Name = "btnResetConn";
            this.btnResetConn.Size = new System.Drawing.Size(226, 42);
            this.btnResetConn.TabIndex = 10;
            this.btnResetConn.Text = "Reset Connection";
            this.btnResetConn.UseCompatibleTextRendering = true;
            this.btnResetConn.UseVisualStyleBackColor = false;
            this.btnResetConn.Click += new System.EventHandler(this.btnResetConn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(656, 158);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 9;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(411, 56);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHigh.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblHigh.Location = new System.Drawing.Point(597, 177);
            this.lblHigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(52, 24);
            this.lblHigh.TabIndex = 12;
            this.lblHigh.Text = "High";
            this.lblHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.label2.Location = new System.Drawing.Point(1062, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "low updates frequency";
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1388, 1020);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnResetConn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.logoImg);
            this.Controls.Add(this.dataGridview);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DemoForm";
            this.Text = "Lightstreamer .NET Client Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridView dataGridview;
        private System.Windows.Forms.PictureBox logoImg;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnResetConn;
        protected System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn PctChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ask;
        private System.Windows.Forms.DataGridViewTextBoxColumn AskQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenPrice;
        private System.Windows.Forms.DataGridViewImageColumn ChartBtn;
    }
}