using CRM.Context;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        MenuWindow MenuWindow;
        bool Edit = false;
        int ID = -1;
        string FilePath;
        string Contract = "";
        public AddClientPage(MenuWindow menuWindow)
        {
            InitializeComponent();
            MenuWindow = menuWindow;
        }
        public AddClientPage(MenuWindow menuWindow,int id,string contract)
        {
            InitializeComponent();
            MenuWindow = menuWindow;
            Edit = true;
            ID = id;
            Contract = contract;
            AddOrEditButtonC.Content = "Редактировать клиента";
            using (var db = new CRM_Model()) 
            {
                var item = db.GetClient(ID);
                TB_TitleC.Text = item.TitleCompany;
                TB_LastName.Text = item.LastName;
                TB_FirstName.Text = item.FirstName;
                TB_Patronymic.Text = item.Patronymic;
                TB_Phone.Text = item.Phone;
                TB_Address.Text = item.AddressCompany;
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                if (!db.StringIsEmpty(item.Photo))                 
                    bm.UriSource = new Uri(item.Photo, UriKind.Relative);
                else 
                    bm.UriSource = new Uri(dir+ "NoPhoto.PNG", UriKind.Relative); ;
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.EndInit();
                I_PhotoC.Source = bm;
            }
        }

        private void ButtonImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.png)|*.png|Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }        
            BitmapImage bm = new BitmapImage();
            bm.BeginInit();
            bm.UriSource = new Uri(FilePath, UriKind.Relative);
            bm.CacheOption = BitmapCacheOption.OnLoad;
            bm.EndInit();
            I_PhotoC.Source = bm;
        }

        private void AddOrEditButtonC_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                if (!Edit)
                {
                    MessageBox.Show(db.AddClient(TB_TitleC.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, TB_Phone.Text, Contract, TB_Address.Text, FilePath));
                }
                else
                {
                        MessageBox.Show(db.EditClient(ID, TB_TitleC.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, TB_Phone.Text, Contract, TB_Address.Text, FilePath));
                }
                MenuWindow.MainFrame.Navigate(new ClientListPage(MenuWindow));
            }
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
