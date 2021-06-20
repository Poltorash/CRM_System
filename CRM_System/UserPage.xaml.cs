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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        MenuWindow MenuWindow;
        public UserPage(MenuWindow menu)
        {
            InitializeComponent();
            MenuWindow = menu;
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DGR_User.ItemsSource = null;
            using (var db = new CRM_Model())
            {
                DGR_User.ItemsSource = db.GetUsers();
            }
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddUserPage(MenuWindow));

        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddUserPage(MenuWindow, Convert.ToInt32(DGR_User.SelectedValue)));
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                MessageBox.Show(db.RemoveUser(Convert.ToInt32(DGR_User.SelectedValue)));
                UpdateDataGrid();
            }
        }
    }
}
