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
    /// Логика взаимодействия для AddRequestPage.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {
        MenuWindow MenuWindow;
        List<RequestParams> Params;
        public AddRequestPage(MenuWindow menu)
        {
            InitializeComponent();
            MenuWindow = menu;
            Params =new List<RequestParams>();
            UpdateComboBox();
        }
        private void UpdateComboBox() 
        {
            CB_Client.ItemsSource = null;
            CB_Product.ItemsSource = null;
            using (var db = new CRM_Model())
            {
                CB_Client.ItemsSource = db.Clients.ToList();
                CB_Product.ItemsSource = db.Products.ToList();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CRM_Model())
            {
                Params.Add(new RequestParams()
                {
                    id = Convert.ToInt32(CB_Product.SelectedValue),
                    quantity = Convert.ToInt32(TB_Quantity.Text),
                    sum = db.Sum(Convert.ToInt32(CB_Product.SelectedValue), Convert.ToInt32(TB_Quantity.Text))
                });    
                MessageBox.Show("Продукция добавлена");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime date;
            int id;
            string message;
            using (var db = new CRM_Model())
            {
                date= Convert.ToDateTime(DP_Date.SelectedDate);
                id= Convert.ToInt32(CB_Client.SelectedValue);
                message = db.AddRequest(date, id);               
                db.AddProduct_Of_Request(db.GetRequestIDInLast(),Params);
            }
            MessageBox.Show(message);
            MenuWindow.MainFrame.Navigate(new RequestPage(MenuWindow));
        }
    }
}
