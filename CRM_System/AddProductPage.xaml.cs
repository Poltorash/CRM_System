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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        MenuWindow MenuWindow;
        bool Edit = false;
        int ID = -1;
        string FilePath;
        public AddProductPage()
        {
            InitializeComponent();
            using (var db = new CRM_Model())
            {
                Cb_Type.ItemsSource = db.Product_Types.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonImage_Click(object sender, RoutedEventArgs e)
        {
            try
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
                I_PhotoP.Source = bm;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
