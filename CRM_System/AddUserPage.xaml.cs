using CRM.Context;
using CRM.Model;
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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        MenuWindow MenuWindow;
        int ID = -1;
        public AddUserPage(MenuWindow menu)
        {
            InitializeComponent();
            MenuWindow = menu;
            CB();
        }

        public AddUserPage(MenuWindow menu, int id)
        {
            InitializeComponent();
            BtnAdd.Content = "Редактировать пользователя";
            MenuWindow = menu;
            ID = id;
            CB();
            using (var db = new CRM_Model()) 
            {
                var item = db.GetUsersInID(ID);
                TB_Login.Text = item.UserLogin;
                TB_Password.Text = item.UserPassword;
                if (item.UserStatus == UserStatus.Администратор)
                    Cb_Status.SelectedIndex = 0;
                else
                    Cb_Status.SelectedIndex = 1;
            }
        }

        public void CB() 
        {
            Cb_Status.Items.Add("Администратор");
            Cb_Status.Items.Add("Пользователь");
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserStatus userStatus = UserStatus.Администратор;
            using (var db = new CRM_Model())
            {
                if (ID == -1)
                    MessageBox.Show(db.AddUser(TB_Login.Text, TB_Password.Text));
                else
                {
                    if (Cb_Status.Text != userStatus.ToString())
                        userStatus = UserStatus.Пользователь;
                    MessageBox.Show(db.EditUser(ID, TB_Login.Text, TB_Password.Text,userStatus));
                   
                }
            }
            MenuWindow.MainFrame.Navigate(new UserPage(MenuWindow));
        }
    }
}
