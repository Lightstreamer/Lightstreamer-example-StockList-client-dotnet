using com.lightstreamer.client;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DotNetStockListDemo
{
    public delegate void LightstreamerChartUpdateDelegate(int item, ItemUpdate values);

    public partial class ChartQuotes : Form
    {
        public ObservableCollection<Record> quotessource = new ObservableCollection<Record>();

        public double minvisual = 1000.0;

        public static Series series;

        private string name;

        private string item;

        private StocklistClient lsClient;

        private Color color;

        ToolTip tooltip = new ToolTip();

        Point? prevPosition = null;

        Point? clickPosition = null;

        static Random rnd = new Random();
        public ChartQuotes(string item, string name, StocklistClient lsClient)
        {
            InitializeComponent();

            Console.WriteLine("Item for chart: " + item);

            this.item = item;
            this.name = name;
            this.lsClient = lsClient;

            double caso = rnd.NextDouble();
            if ( caso < 0.33 )
            {
                color = Color.DodgerBlue;
            } 
            else if (caso < 0.66)
            {
                color = Color.DarkOrange;
            } 
            else
            {
                color = Color.DarkGreen;
            }
        }
        private void ChartQuotes_Load(object sender, EventArgs e)
        {

            chartQ.Series.Clear();

            Title title = new Title();
            title.Font = new Font("Gadugi", 24, FontStyle.Italic);
            title.ForeColor = color;
            title.Text = name + " quotes";
            chartQ.Titles.Add(title);

            chartQ.Legends.Clear();

            chartQ.DataSource = quotessource;

            Series series1 = new Series(name + " quotes");
            series1.ChartType = SeriesChartType.Line;
            chartQ.Series.Add(series1);

            // Adjust the series data members. 
            series1.XValueMember = "time";
            series1.YValueMembers = "quote";
            series1.Color = color;
            series1.Font = new Font("Gadugi", 14, FontStyle.Bold);
            series1.BorderWidth = 3;

            chartQ.DataBind();

            Console.WriteLine("Start subscription ...");

            lsClient.subscribeChart(item, this);
        }

        public void OnLightstreamerUpdate(int item, ItemUpdate values)
        {
            lock (quotessource)
            {
                chartQ.SuspendLayout();

                chartQ.DataBind();
                chartQ.ChartAreas[0].AxisY.Minimum = minvisual - (minvisual * 0.01);
                chartQ.ChartAreas[0].RecalculateAxesScale();

                chartQ.ResumeLayout();
            }
        }

        private void Charter(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("Rebind chart!");
            lock (quotessource)
            {
                chartQ.DataBind();
            }
        }

        private void ChartQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            lsClient.stopSubscribeChart(this);
        }
    }

    public class Record
    {
        int id;
        string time;
        double quote;
        public Record(int id, string time, double q)
        {
            this.id = id;
            this.time = time;
            this.quote = q;
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public double Quote
        {
            get { return quote; }
            set { quote = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}