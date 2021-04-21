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
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        MenuWindow MenuWindow;
        public ProductListPage(MenuWindow menuWindow)
        {
            MenuWindow = menuWindow;
            InitializeComponent();
            UpdateComboBox();
        }
        private void UpdateComboBox() 
        {
            LVProduct.ItemsSource = null;
            using (var db = new CRM_Model())
            {
                LVProduct.ItemsSource = db.GetAllProduct();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddProductPage(MenuWindow));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MenuWindow.MainFrame.Navigate(new AddProductPage(MenuWindow,Convert.ToInt32(LVProduct.SelectedValue)));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                MessageBox.Show(db.RemoveProduct(Convert.ToInt32(LVProduct.SelectedValue)));
                UpdateComboBox();
            }
        }
    }
}
