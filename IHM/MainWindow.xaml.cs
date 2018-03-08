using Composants;
using Methode;
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
        Commande commandeEnCourDEdition;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new BindingDataGrid();
            ComboBoxColumn.ItemsSource = new BindingDataGrid().Unites;
            commandeEnCourDEdition = new Commande();
            
        }
        

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if(this.tbNom.Text == "")
            {
                MessageBox.Show("Veuillez données un nom a votre bon de commande", "Erreur");
            }
            else
            {
                List<LigneCommande> listeDesLignes = (List<LigneCommande>)this.BonDeCommande.ItemsSource;

                foreach (var ligne in listeDesLignes)
                {
                    CommandeDAO.insertObject(ligne);
                }

                this.dtgBonDeCommande.ItemsSource = null;
                this.dtgBonDeCommande.ItemsSource = CommandeDAO.getCommandes();
                this.BonDeCommande.ItemsSource = null;
                commandeEnCourDEdition = null;


            }
        }

        private void btnNewCommande_Click(object sender, RoutedEventArgs e)
        {
            this.BonDeCommande.ItemsSource = null;
            commandeEnCourDEdition = null;
            commandeEnCourDEdition = new Commande(this.tbNom.Text);
            commandeEnCourDEdition = CommandeDAO.insertObject(commandeEnCourDEdition);

        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            commandeEnCourDEdition = null;
            commandeEnCourDEdition = (Commande)this.dtgBonDeCommande.SelectedItem;
            this.tbNom.Text = commandeEnCourDEdition.Nom;
            List<LigneCommande> ligneCommandeTemp = new List<LigneCommande>();
            

            this.BonDeCommande.ItemsSource = null;


            foreach (var ligneCommande in commandeEnCourDEdition.LignesCommande)
            {
                ligneCommandeTemp.Add(ligneCommande);
            }

            this.BonDeCommande.ItemsSource = ligneCommandeTemp;



        }

        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            string namePiece = this.cbPiece.Text;
            Piece newPiece = new Piece(namePiece);
            List<LigneCommande> listeLigneCommande;

            if (this.BonDeCommande.ItemsSource == null)
            {
                listeLigneCommande  = new List<LigneCommande>();
            }
            else
            {
                 listeLigneCommande = (List<LigneCommande>)this.BonDeCommande.ItemsSource;
            }


            listeLigneCommande.Add(new LigneCommande(newPiece, commandeEnCourDEdition, 0));

            this.BonDeCommande.ItemsSource = null;
            this.BonDeCommande.ItemsSource = listeLigneCommande;

        }
    }
}
