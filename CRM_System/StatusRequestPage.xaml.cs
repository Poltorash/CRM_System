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
    /// Логика взаимодействия для StatusRequestPage.xaml
    /// </summary>
    public partial class StatusRequestPage : Page
    {
        public StatusRequestPage()
        {
            InitializeComponent();
            Update();
        }
        public void Update() 
        {
            DGRWay.ItemsSource = null;
            DGRProcessed.ItemsSource = null;
            DGRCompleted.ItemsSource = null;
            using (var db = new CRM_Model()) 
            {

                DGRWay.ItemsSource = db.GetRequestOt();
                DGRProcessed.ItemsSource = db.GetRequestOb();
                DGRCompleted.ItemsSource = db.GetRequestCom();
            }
        }
    }
}
