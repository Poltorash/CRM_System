using CRM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        MenuWindow MenuWindow;
        public ReportPage(MenuWindow menu)
        {
            InitializeComponent();
            MenuWindow = menu;
            using (var db = new CRM_Model()) 
            {
                LVClients.ItemsSource = db.GetRequests();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LVClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
