using CRM.Context;
using Microsoft.Win32;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        int ID = 0;
        MenuWindow MenuWindow;
        string FilePath;
        bool Open = false;
        string Contract = "";
        public ProfilePage(MenuWindow menu, int id)
        {
            InitializeComponent();
            MenuWindow = menu;
            ID = id;
            using (var db = new CRM_Model())
            {
                var item = db.GetClient(ID);
                TB_Title.Text = item.TitleCompany;
                TB_LastName.Text = item.LastName;
                TB_FirstName.Text = item.FirstName;
                TB_Patronymic.Text = item.Patronymic;
                TB_Phone.Text = item.Phone;
                TB_Address.Text = item.AddressCompany;
                TB_Status.Text = item.ClientStatus.ToString();
                Contract = item.ContractPath;
                if (db.StringIsEmpty(item.ContractPath))
                    BT_Contract.Content = "Добавить договор";
                else
                    Open = true;
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                if (!db.StringIsEmpty(item.Photo))
                    bm.UriSource = new Uri(item.Photo, UriKind.Relative);
                else
                    bm.UriSource = new Uri(dir + "NoPhoto.PNG", UriKind.Relative); ;
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.EndInit();
                I_ProfilePhoto.Source = bm;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddClientPage(MenuWindow, ID));
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.png)|*.png|Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                }
                string dir = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"CRM_System.exe", "");
                BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    if (!db.StringIsEmpty(FilePath))
                        bm.UriSource = new Uri(FilePath, UriKind.Relative);
                    else
                        bm.UriSource = new Uri(dir + "NoPhoto.PNG", UriKind.Relative); ;
                    bm.CacheOption = BitmapCacheOption.OnLoad;
                    bm.EndInit();
                    I_ProfilePhoto.Source = bm;
                    MessageBox.Show(db.EditPhotoClient(ID, FilePath));
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                MessageBox.Show(db.RemoveClient(ID));
               MenuWindow.MainFrame.Navigate(new ClientListPage(MenuWindow));
            }

        }

        private void BT_Contract_Click(object sender, RoutedEventArgs e)
        {
            if (!Open)
            {
                using (var db = new CRM_Model())
                {
                    Contract = db.Contract($"{TB_LastName.Text}" + " " + $"{TB_FirstName.Text[0]}" + "." + $"{TB_Patronymic.Text[0]}" + ".", TB_Title.Text);
                    db.EditContract(ID, Contract);
                    BT_Contract.Content = "Открыть договор";
                    TB_Status.Text = "Договор";
                }
            }
            else
            {
                using (var db = new CRM_Model())
                {
                    db.OpenContract(Contract);
                }
            }
        }
    }
}
