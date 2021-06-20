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
using CRM.Context;

namespace CRM_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void Btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Btn_Autorization_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model()) 
            {
                int user = db.Authorization(TB_Login.Text,PasswordB.Password);
                if (user != 0)
                {
                    MenuWindow menu = new MenuWindow(user);
                    menu.Show();
                    this.Close();
                }
                else MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}
