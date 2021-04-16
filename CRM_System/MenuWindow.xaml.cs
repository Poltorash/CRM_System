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
using System.Windows.Shapes;

namespace CRM_System
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ClientListPage(this));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductListPage(this));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientListPage(this));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RequestPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportPage(this));
        }
    }
}
