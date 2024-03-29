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

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Runtime.InteropServices;
using com.lightstreamer.client;
using System.Collections.Generic;

namespace DotNetStockListDemo
{

    public delegate void LightstreamerUpdateDelegate(int item, ItemUpdate values);
    public delegate void LightstreamerStatusChangedDelegate(int cStatus, string status);

    public delegate void StopDelegate();
    public delegate void BlinkOffDelegate(DataGridViewCell[] cells);

    public partial class DemoForm : Form, IMessageFilter
    {
        private static readonly Color blinkOnColor = Color.Yellow;
        private static readonly Color blinkOffColor = Color.LightGoldenrodYellow;
        private const long blinkTime = 300; // millisecs

        private StocklistClient stocklistClient;
        private ArrayList blinkingCells;
        private bool blinkEnabled;
        private bool blinkMenu;
        private bool isDirty = false;

        private string pushServerUrl;
        private string forceT;
        #region API Declarations

        [DllImport("user32.dll")]
        private static extern int GetSystemMenu(int hwnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern long AppendMenuA(int hMenu, int wFlags, int wIDNewItem, string lpNewItem);

        [DllImport("user32.dll")]
        private static extern long RemoveMenu(int hMenu, int nPosition, int wFlags);

        private const int MF_BYPOSITION = 1024;
        private const int MF_SEPERATOR = 2048;
        private const int MF_REMOVE = 4096;
        private const int WM_SYSCOMMAND = 274;
        private const int WM_KEYDOWN = 256;

        #endregion // API Declarations

        public DemoForm(string pushServerHost, int pushServerPort, string forceTransport)
        {
            stocklistClient = null;
            blinkingCells = new ArrayList();
            blinkEnabled = true;
            blinkMenu = false;

            if (pushServerHost == null || pushServerHost.Length == 0)
            {
                pushServerHost = "localhost";
                pushServerPort = 8080;
            }

            if (pushServerHost.StartsWith("http") || pushServerHost.StartsWith("HTTP"))
            {
                pushServerUrl = pushServerHost;
            }
            else
            {
                pushServerUrl = "http://" + pushServerHost + ":" + pushServerPort;
            }

            forceT = forceTransport;

            Thread t = new Thread(new ThreadStart(DeblinkingThread));
            t.Start();

            InitializeComponent();
        }

        private static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                dataGridview.Rows.Add();
            }

            dataGridview.Refresh();

            dataGridview.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dataGridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridview.EnableHeadersVisualStyles = false;

            dataGridview.DefaultCellStyle.Font = new Font("Gadugi", 12, GraphicsUnit.Point);
            dataGridview.DefaultCellStyle.BackColor = Color.AntiqueWhite;
            comboBox1.Text = "Forced Transport to ...";
            comboBox1.BackColor = Color.AntiqueWhite;
            comboBox1.ForeColor = Color.DarkGoldenrod;

            for (int i = 0; i < 30; i++)
            {

                if (IsOdd(i))
                {
                    dataGridview.Rows[i].DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
                }
                else
                {
                    dataGridview.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                }
            }

            Thread t = new Thread(new ThreadStart(StartLightstreamer));
            t.Start();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddBlinkMenu()
        {
            if (blinkMenu) return;
            blinkMenu = true;

            int sysMenuHandle = GetSysMenuHandle((int)Handle);
            AppendSeperator(sysMenuHandle);
            AppendSysMenu(sysMenuHandle, 54321, "Toggle cell blink effect");
        }

        private void StartLightstreamer()
        {



            stocklistClient = new StocklistClient(
                pushServerUrl,
                forceT,
                this,
                new LightstreamerUpdateDelegate(OnLightstreamerUpdate),
                new LightstreamerStatusChangedDelegate(OnLightstreamerStatusChanged));


            stocklistClient.Start();
        }

        private void OnLightstreamerUpdate(int item, ItemUpdate values)
        {
            dataGridview.SuspendLayout();

            if (this.isDirty)
            {
                this.isDirty = false;
                CleanGrid();
            }

            DataGridViewRow row = dataGridview.Rows[item - 1];

            ArrayList cells = new ArrayList();
            foreach (KeyValuePair<int, string> entry in values.ChangedFieldsByPosition)
            {

                DataGridViewCell cell = row.Cells[entry.Key - 1];

                switch (entry.Key - 1)
                {
                    case 1: // last_price          
                    case 5: // bid
                    case 6: // ask
                    case 8: // min
                    case 9: // max
                    case 11: // ref_price
                    case 10: // open_price
                        double dVal = Double.Parse(entry.Value, CultureInfo.GetCultureInfo("en-US").NumberFormat);
                        cell.Value = dVal;
                        break;

                    case 3: // pct_change
                        double dVal2 = Double.Parse(entry.Value, CultureInfo.GetCultureInfo("en-US").NumberFormat);
                        cell.Value = dVal2;
                        cell.Style.ForeColor = ((dVal2 < 0.0) ? Color.Red : Color.Green);
                        break;

                    case 4: // bid_quantity
                    case 7: // ask_quantity
                        int lVal = Int32.Parse(entry.Value);
                        cell.Value = lVal;
                        break;

                    case 2: // time
                        DateTime dtVal = DateTime.Parse(entry.Value);
                        cell.Value = dtVal;
                        break;

                    case 0: // stock_name, ...
                        cell.Value = entry.Value;
                        break;

                    default:
                        break;
                }

                // cell.Value = entry.Value;

                if (blinkEnabled)
                {
                    if (cell.ColumnIndex < 12)
                    {
                        cell.Style.BackColor = blinkOnColor;
                        cells.Add(cell);
                    }
                    
                }
            }

            dataGridview.ResumeLayout();

            if (blinkEnabled)
            {
                long now = DateTime.Now.Ticks;
                ScheduleBlinkOff(cells, now);
            }
        }

        private void OnLightstreamerStatusChanged(int cStatus, string status)
        {
            statusLabel.Text = status;


            switch (cStatus)
            {
                case StocklistConnectionListener.STREAMING:
                    lblStatus.BackColor = Color.LightGreen;
                    if (status.Contains("HTTP"))
                    {
                        lblStatus.Text = "HTTP";
                    }
                    else
                    {
                        lblStatus.Text = "WS";
                    }

                    break;
                case StocklistConnectionListener.POLLING:
                    lblStatus.BackColor = Color.GreenYellow;
                    lblStatus.Text = "Poll";
                    break;
                case StocklistConnectionListener.STALLED:
                    lblStatus.BackColor = Color.LightSalmon;
                    lblStatus.Text = "...";
                    break;
                case StocklistConnectionListener.DISCONNECTED:
                    lblStatus.BackColor = Color.OrangeRed;
                    lblStatus.Text = "--";
                    break;
                default:
                    break;
            }

            this.Refresh();
        }

        private void CleanGrid()
        {
            for (int row = 0; row < dataGridview.Rows.Count; row++)
            {
                for (int col = 0; col < dataGridview.Rows[row].Cells.Count; col++)
                {
                    dataGridview.Rows[row].Cells[col].Value = "";
                }
            }
        }

        private class BlinkingCell
        {
            public readonly DataGridViewCell cell;
            public readonly long timestamp;

            public BlinkingCell(DataGridViewCell dataGridviewCell, long blinkOnTimestamp)
            {
                cell = dataGridviewCell;
                timestamp = blinkOnTimestamp;
            }
        }

        private void ScheduleBlinkOff(ArrayList cells, long blinkOnTimestamp)
        {
            lock (blinkingCells)
            {
                for (int j = 0; j < cells.Count; j++)
                {
                    DataGridViewCell cell = (DataGridViewCell)cells[j];

                    blinkingCells.Add(new BlinkingCell(cell, blinkOnTimestamp));
                }

                Monitor.Pulse(blinkingCells);
            }
        }

        private void BlinkOff(DataGridViewCell[] cells)
        {
            dataGridview.SuspendLayout();

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].Style.BackColor = blinkOffColor;
            }

            dataGridview.ResumeLayout();
        }

        private void DeblinkingThread()
        {
            ArrayList expiredBlinkingCells = new ArrayList();

            do
            {
                expiredBlinkingCells.Clear();

                lock (blinkingCells)
                {
                    if (blinkingCells.Count == 0)
                        Monitor.Wait(blinkingCells);

                    expiredBlinkingCells.AddRange(blinkingCells);
                    blinkingCells.Clear();
                }

                DataGridViewCell[] cells = new DataGridViewCell[expiredBlinkingCells.Count];
                for (int i = 0; i < expiredBlinkingCells.Count; i++)
                {
                    cells[i] = ((BlinkingCell)expiredBlinkingCells[i]).cell;
                }

                BlinkingCell lastBlinkingCell = (BlinkingCell)expiredBlinkingCells[expiredBlinkingCells.Count - 1];

                long now = DateTime.Now.Ticks;
                long diff = (now - lastBlinkingCell.timestamp) / 10000; // millisecs
                if (diff < blinkTime)
                    Thread.Sleep((int)(blinkTime - diff));

                Invoke(new BlinkOffDelegate(BlinkOff), new object[] { cells });

            } while (true);
        }

        #region System Menu API

        public int GetSysMenuHandle(int frmHandle)
        {
            return GetSystemMenu(frmHandle, false);
        }

        private long RemoveSysMenu(int mnuHandle, int mnuPosition)
        {
            return RemoveMenu(mnuHandle, mnuPosition, MF_REMOVE);
        }

        private long AppendSysMenu(int mnuHandle, int MenuID, string mnuText)
        {
            return AppendMenuA(mnuHandle, 0, MenuID, mnuText);
        }

        private long AppendSeperator(int mnuHandle)
        {
            return AppendMenuA(mnuHandle, MF_SEPERATOR, 0, null);
        }

        public bool PreFilterMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_KEYDOWN:
                    Keys key = ((Keys)msg.WParam.ToInt32()) & Keys.KeyCode;
                    switch (key)
                    {
                        case Keys.F12:
                            AddBlinkMenu();
                            break;
                    }
                    break;
            }

            return false;
        }

        protected override void WndProc(ref Message messg)
        {
            switch (messg.Msg)
            {
                case WM_SYSCOMMAND:
                    switch (messg.WParam.ToInt32())
                    {
                        case 54321:
                            blinkEnabled = !blinkEnabled;
                            break;
                    }
                    break;
            }

            base.WndProc(ref messg);

        }

        #endregion // System Menu API

        private void btnResetConn_Click(object sender, EventArgs e)
        {
            stocklistClient.Reset();
            trackBar1.Value = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stocklistClient.ForceTransport(comboBox1.SelectedItem.ToString());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            stocklistClient.MaxFrequency(trackBar1.Value);
        }

        private void dataGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChartQuotes cq = new ChartQuotes("item" + (e.RowIndex + 1), dataGridview.Rows[e.RowIndex].Cells[0].Value.ToString(), stocklistClient);
            cq.Show();
        }
    }
}