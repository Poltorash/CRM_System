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
using System.Windows.Shapes;

namespace CRM_System
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                if (!db.StringIsEmpty(TB_Login.Text)
                    && !db.StringIsEmpty(PasswordB.Password)
                    && !db.StringIsEmpty(PasswordB2.Password))
                {
                    if (PasswordB.Password == PasswordB2.Password)
                    {
                        MessageBox.Show(db.AddUser(TB_Login.Text, PasswordB.Password));
                        MenuWindow menu = new MenuWindow();
                        menu.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Пароли не совпадают");
                }
                else MessageBox.Show("Есть пустые поля");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
