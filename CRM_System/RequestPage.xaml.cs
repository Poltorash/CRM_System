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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        MenuWindow MenuWindow;
        public RequestPage(MenuWindow menu)
        {
            InitializeComponent();
            MenuWindow = menu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddRequestPage(MenuWindow));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model()) 
            {
                MessageBox.Show(db.EditRequestStatus(Convert.ToInt32(DGR_Request.SelectedValue)));;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model()) 
            {
                MessageBox.Show(db.RemoveRequest(Convert.ToInt32(DGR_Request.SelectedValue)));
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
