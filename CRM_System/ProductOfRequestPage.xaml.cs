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
    /// Логика взаимодействия для ProductOfRequestPage.xaml
    /// </summary>
    public partial class ProductOfRequestPage : Page
    {
        public ProductOfRequestPage(int id)
        {
            InitializeComponent();
            DGR_Request.ItemsSource = null;
            using (var db = new CRM_Model()) 
            {
                DGR_Request.ItemsSource = db.GetProducts(id);
            }
        }
    }
}
