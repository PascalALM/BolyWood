﻿using System;
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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new BindingDataGrid();
            ComboBoxColumn.ItemsSource = new BindingDataGrid().Unites;
        }

        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(BonDeCommande.ToString());
        }
    }
}
