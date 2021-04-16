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
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        MenuWindow MenuWindow;
        public ClientListPage(MenuWindow menuWindow)
        {
            InitializeComponent();
            MenuWindow = menuWindow;
            using (var db = new CRM_Model()) 
            {
                LVClients.ItemsSource = db.GetAllClient();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddClientPage(MenuWindow));
        }

        private void LVClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new ProfilePage(MenuWindow,Convert.ToInt32(LVClients.SelectedValue)));
        }
    }
}
