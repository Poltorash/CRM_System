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
            //LoadPieChartData();
        }

        private void LoadColumnChartData()
        {
            using (var db = new CRM_Model())
            {
                double[] mass = new double[5];
                var product = db.GetAllRequest();
                for (int i = mass.Length - 1; i > 0; i--)
                {
                    var count = db.Count(i - 1);
                    if (count != -1)
                        mass[i] = count;
                    else
                        mass[i] = 0;
                }
                var key = new Dictionary<string, double>();
                for (int i = 0; i < mass.Length; i++)
                {
                    if (db.Month(i) != "")
                        key.Add(db.Month(i), mass[i]);
                }
                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = key;
                ((PieSeries)PieChart.Series[0]).ItemsSource = key;
            }
        }
    }
}
