using CRM.Context;
using System;
using System.Collections.Generic;
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
                for (int i = 12; i > 0; i--)
                {
                    count.Add(db.CountClient(i-1));
                }
                var key = new Dictionary<string, double>();
                foreach (var ticket in count)
                {
                    key.Add(ticket.Month, ticket.Quantity);
                }
               ((LineSeries)LineChart.Series[0]).ItemsSource = key;
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
                ((LineSeries)LineChart.Series[0]).ItemsSource = ticketkey;
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
    }
}
