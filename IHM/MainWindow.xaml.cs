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
            commandeEnCourDEdition = null;

        }
        

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.tbNom.Text))
            {
                MessageBoxResult result = MessageBox.Show("Merci de renseigner un nom avant de créer un bon de commande", "Erreur");

                this.tbNom.Focus();
            } else if (commandeEnCourDEdition != null)
            {
                List<LigneCommande> listeDesLignes = (List<LigneCommande>)this.BonDeCommande.ItemsSource;

                foreach (var ligne in listeDesLignes)
                {
                    CommandeDAO.insertLigneCommande(ligne);
                    //CommandeDAO.insertObject(ligne);
                }

                this.dtgBonDeCommande.ItemsSource = null;
                this.dtgBonDeCommande.ItemsSource = CommandeDAO.getCommandes();
                this.BonDeCommande.ItemsSource = null;
                commandeEnCourDEdition = null;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Aucune commande n'est sélectionnée", "Erreur");
            }
        }

        private void btnNewCommande_Click(object sender, RoutedEventArgs e)
        {
            this.BonDeCommande.ItemsSource = null;
            if(String.IsNullOrEmpty(this.tbNom.Text))
            {
                MessageBoxResult result = MessageBox.Show("Merci de renseigner un nom avant de créer un bon de commande", "Erreur");

                this.tbNom.Focus();
            } else
            {
                commandeEnCourDEdition = null;
                commandeEnCourDEdition = new Commande(this.tbNom.Text);
                commandeEnCourDEdition = CommandeDAO.insertObject(commandeEnCourDEdition);

                MessageBoxResult result = MessageBox.Show("La commande a été créée", "Succès");

            }

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
            if(commandeEnCourDEdition != null)
            {
                string namePiece = this.cbPiece.Text;
                Piece piece = CommandeDAO.getPieceByName(namePiece);
                List<LigneCommande> listeLigneCommande;

                if (this.BonDeCommande.ItemsSource == null)
                {
                    listeLigneCommande = new List<LigneCommande>();
                }
                else
                {
                    listeLigneCommande = (List<LigneCommande>)this.BonDeCommande.ItemsSource;
                }


                listeLigneCommande.Add(new LigneCommande(piece, commandeEnCourDEdition, 0));

                this.BonDeCommande.ItemsSource = null;
                this.BonDeCommande.ItemsSource = listeLigneCommande;
            } else
            {
                MessageBoxResult result = MessageBox.Show("Aucune commande n'est sélectionnée", "Erreur");
            }
        }
    }
}
