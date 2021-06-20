using CRM.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM_System
{
    /// <summary>
    /// Логика взаимодействия для ChartsPage.xaml
    /// </summary>
    public partial class ChartsPage : Page
    {
        public ChartsPage()
        {
            InitializeComponent();

            LoadColumnChartData();
            LoadPieChartData();
            LoadLineChartData();
            LoadColumnChartDataClient();
        }

        private void LoadColumnChartData()
        {
            using (var db = new CRM_Model())
            {
                var count = new List<SumInYearParam>();
                for (int i = 12; i > 0; i--)
                {
                    count.Add(db.Count(i-1));                  
                }
                var key = new Dictionary<string, double>();
                foreach (var sum in count) 
                {                  
                    key.Add(sum.Month, sum.Sum);
                }
                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = key;             
            }
        }
        private void LoadPieChartData() 
        {
            using (var db = new CRM_Model())
            {
                var key = new Dictionary<string, double>();
                foreach (var count in db.CountProductInMonth())
                {
                    key.Add(count.Title, count.Sum);
                }
                ((PieSeries)PieChart.Series[0]).ItemsSource = key;
            }
        }
        private void LoadLineChartData()
        {
            using (var db = new CRM_Model())
            {
                var count = new List<TicketOrClientrParam>();
                    count = db.CountClient();
                var key = new Dictionary<string, double>();
                foreach (var ticket in count)
                {
                    key.Add(ticket.TitleStatus, ticket.Quantity);
                }
               ((PieSeries)LineChart.Series[0]).ItemsSource = key;
            }
        }
        private void LoadColumnChartDataClient()
        {
            using (var db = new CRM_Model())
            {
                var count = new List<TicketOrClientrParam>();
                for (int i = 12; i > 0; i--)
                {
                    count.Add(db.CountTicket(i-1));
                }
                var key = new Dictionary<string, double>();
                foreach (var ticket in count)
                {
                    key.Add(ticket.Month, ticket.Quantity);
                }
               ((ColumnSeries)ColumnChartClient.Series[0]).ItemsSource = key;
            }
        }


        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                var sumInYears = new List<SumInYearParam>();
                var tickets = new List<TicketOrClientrParam>();
                var clientrs = new List<TicketOrClientrParam>();
                var CountProduct = new List<ProductCountsParam>();

                var key = new Dictionary<string, double>();
                var sumInYearkey = new Dictionary<string, double>();
                var ticketkey = new Dictionary<string, double>();
                var clientrkey = new Dictionary<string, double>();

                DateTime first = (DateTime)DPDateStart.SelectedDate;             
                DateTime last = (DateTime)DPDateEnd.SelectedDate;
                CountProduct = db.CountProductInMonth(first,last);
                for (DateTime i = first; i <= last;)
                {
                    sumInYears.Add(db.Count(i));
                    tickets.Add(db.CountTicket(i));
                    clientrs.Add(db.CountClient(i));
                    i = i.AddMonths(1);
                }
               
                foreach (var column in sumInYears)
                {
                    sumInYearkey.Add(column.Month, column.Sum);
                }
                foreach (var pie in CountProduct)
                {
                    key.Add(pie.Title, pie.Sum);
                }
                foreach (var Line in tickets)
                {
                    ticketkey.Add(Line.Month, Line.Quantity);
                }
                foreach (var column in clientrs)
                {
                    clientrkey.Add(column.Month, column.Quantity);
                }

                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = sumInYearkey;
                ((PieSeries)PieChart.Series[0]).ItemsSource = key;
                //((LineSeries)LineChart.Series[0]).ItemsSource = ticketkey;
                ((ColumnSeries)ColumnChartClient.Series[0]).ItemsSource = clientrkey;
            }
        }

        private void BtnStandart_Click(object sender, RoutedEventArgs e)
        {
            LoadColumnChartData();
            LoadPieChartData();
            LoadLineChartData();
            LoadColumnChartDataClient();
        }
        //public void RenderLine()
        //{
        //    string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
        //    var renderBitmap = new RenderTargetBitmap((int)LineChart.ActualWidth, (int)LineChart.ActualHeight, 96, 96, PixelFormats.Default);
        //    renderBitmap.Render(LineChart);
        //    BitmapEncoder encoder = new JpegBitmapEncoder();
        //    string filename = $@"{dir}\Grafics\Line.jpg";
        //    // pop up save file dialog, get file name & encoder type (jpg, bmp, png, etc.)
        //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
        //    FileStream fs = new FileStream(filename, FileMode.Create);
        //    encoder.Save(fs);
        //    fs.Flush();
        //    fs.Close();
        //}
        public void RenderColumn()
        {
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
            var renderBitmap = new RenderTargetBitmap((int)ColumnChart.ActualWidth, (int)ColumnChart.ActualHeight, 96, 96, PixelFormats.Default);
            renderBitmap.Render(ColumnChart);
            BitmapEncoder encoder = new JpegBitmapEncoder();
            string filename = $@"{dir}\Grafics\Column.jpg";
            // pop up save file dialog, get file name & encoder type (jpg, bmp, png, etc.)
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            FileStream fs = new FileStream(filename, FileMode.Create);
            encoder.Save(fs);
            fs.Flush();
            fs.Close();
        }
        //public void RenderPie()
        //{
        //    string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
        //    var renderBitmap = new RenderTargetBitmap((int)PieChart.ActualWidth, (int)PieChart.ActualHeight, 100, 100, PixelFormats.Default);
        //    renderBitmap.Render(PieChart);
        //    BitmapEncoder encoder = new JpegBitmapEncoder();
        //    string filename = $@"{dir}\Grafics\Pie.png";
        //    // pop up save file dialog, get file name & encoder type (jpg, bmp, png, etc.)
        //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
        //    FileStream fs = new FileStream(filename, FileMode.Create);
        //    encoder.Save(fs);
        //    fs.Flush();
        //    fs.Close();
        //}
        //public void RenderColumnChartClient()
        //{
        //    string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
        //    var renderBitmap = new RenderTargetBitmap((int)ColumnChartClient.ActualWidth, (int)ColumnChartClient.ActualHeight, 96, 96, PixelFormats.Default);
        //    renderBitmap.Render(ColumnChartClient);
        //    BitmapEncoder encoder = new JpegBitmapEncoder();
        //    string filename = $@"{dir}\Grafics\ColumnChartClient.jpg";
        //    // pop up save file dialog, get file name & encoder type (jpg, bmp, png, etc.)
        //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
        //    FileStream fs = new FileStream(filename, FileMode.Create);
        //    encoder.Save(fs);
        //    fs.Flush();
        //    fs.Close();
        //}
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            //RenderLine();
            RenderColumn();
            //RenderPie();
            //RenderColumnChartClient();
        }
    }
}
