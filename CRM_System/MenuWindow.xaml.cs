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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        int ID = 0;
        public MenuWindow(int id)
        {
            InitializeComponent();
            MainFrame.Navigate(new ClientListPage(this));
            ID = id;
            using (var db = new CRM_Model()) 
            {
                if (!db.StatusAdmin(id)) 
                {
                    LVUser.Visibility = Visibility.Hidden;
                } 
            }
            //using (var db = new CRM_Model())
            //{
            //    db.AddProduct_Type("Квас");
            //    db.AddProduct_Type("Лимонад");
            //    db.AddProduct_Type("Вода");
            //    db.AddProduct_Type("Морс");
            //}
            //using (var db = new CRM_Model())
            //{
            //    db.AddProduct("Квас Традиционный", 50, "", 1);
            //    db.AddProduct("Квас Хлебный", 50, "", 1);
            //    db.AddProduct("Квас Окрошечный", 50, "", 1);
            //    db.AddProduct("Квас Фирменный", 50, "", 1);
            //    db.AddProduct("Лимонад", 35, "", 2);
            //    db.AddProduct("Барбарис", 35, "", 2);
            //    db.AddProduct("Дюшес", 35, "", 2);
            //    db.AddProduct("Тархун", 35, "", 2);
            //    db.AddProduct("Вода газ.", 15, "", 3);
            //    db.AddProduct("Вода негаз.", 15, "", 3);
            //    db.AddProduct("Морс черная смородина", 65, "", 4);
            //    db.AddProduct("Морс брусника", 65, "", 4);
            //    db.AddProduct("Морс клюква", 65, "", 4);
            //}
            //using (var db = new CRM_Model())
            //{
            //    db.AddClient("ИП Стрела", "Иванов", "Сергей", "Андреевич", "89011263740", "", "Терешкова 34", "");
            //    db.AddClient("ИП Ромашка", "Смирнов", "Андрей", "Васильевич", "89762549090", "", "Терешкова 34", "");
            //    db.AddClient("ИП Калина", "Рябинина", "Юлия", "Васильевна", "891236704368", "", "Братьев Башиловых 7", "");
            //    db.AddClient("ИП Маланчев", "Маланчев", "Игорь", "Петрович", "89090923764", "", "Народная 22", "");
            //    db.AddClient("ИП Бородина Т.Ю.", "Бородина", "Татьяна", "Юрьевна", "89673903267", "", "Донгузская 15", "");
            //    db.AddClient("ООО Магнит", "Прохор", "Даниил", "Дмитриевич", "89676889432", "", "Туркестанская 36", "");
            //    db.AddClient("ООО Пятерочка", "Андреева", "Мария", "Ивановна", "89128384022", "", "Чкалова 32", "");
            //    db.AddClient("ИП Емельянов", "Емельянов", "Елисей", "Евгеньевич", "89882930476", "", "Новая 56", "");
            //    db.AddClient("ИП Павлов А.М.", "Павлов", "Артем", "Максимович", "89110256348", "", "Пролетарская 271", "");
            //    db.AddClient("ИП Ламакина", "Ламакина", "Ирина", "Александровна", "89228921037", "", "пр Победы 19", "");
            //}
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Collapsed;
            BtnCloseMenu.Visibility = Visibility.Visible;
        }

        private void BtnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnOpenMenu.Visibility = Visibility.Visible;
            BtnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LVCharts_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChartsPage());
        }

        private void LVClients_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientListPage(this));
        }

        private void LVProduct_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductListPage(this));
        }

        private void LVRequest_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RequestPage(this));
        }

        private void LVReport_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportPage(this));
        }

        private void LVStatusRequestl_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StatusRequestPage());
        }

        private void LVUser_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserPage(this));
        }
    }
}
