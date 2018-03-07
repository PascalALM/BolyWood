using Composants;
using Methode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IHM
{
    class BindingDataGrid { 

         public ICollectionView LigneCommandes { get; private set; }
         public ICollectionView Unites { get; private set; }
         public ICollectionView Commandes { get; private set; }





        public BindingDataGrid()
        {


            
            List<string> _unites = new List<string> { "Piece", "Lot", "Gramme", "KiloGramme" };

            List<LigneCommande> _customers = new List<LigneCommande>();
            List<Commande> _bondecommande = CommandeDAO.getCommandes();

            LigneCommandes = CollectionViewSource.GetDefaultView(_customers);
            Unites = CollectionViewSource.GetDefaultView(_unites);
            Commandes = CollectionViewSource.GetDefaultView(_bondecommande);



        }
         
    }
}
