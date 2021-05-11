﻿using CRM.Context;
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
        public MenuWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ClientListPage(this));
            //using (var db = new CRM_Model())
            //{
            //    db.AddProduct_Type("Квас");
            //    db.AddProduct_Type("Лимонад");
            //    db.AddProduct_Type("Вода");
            //    db.AddProduct_Type("Морс");
            //}
            //using (var db = new CRM_Model())
            //{
            //    db.AddProduct("Традиционный", 50, "", 1);
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

        private void LVFunnel_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FunnelPage());
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
    }
}
