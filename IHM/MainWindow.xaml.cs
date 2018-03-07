﻿using Composants;
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
        

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if(this.tbNom.Text == "")
            {
                MessageBox.Show("Veuillez données un nom a votre bon de commande", "Erreur");
            }
            else
            {
                //Do jobs
            }
        }

        private void btnNewCommande_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            Commande commande = (Commande)this.dtgBonDeCommande.SelectedItem;

            MessageBox.Show("", "Woks");
        }
    
    }
}
