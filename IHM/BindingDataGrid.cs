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
         public ICollectionView PiecesAutocomplete { get; private set; }





        public BindingDataGrid()
        {


            
            List<string> _unites = new List<string> { "Piece", "Lot", "Gramme", "KiloGramme" };
            List<string> _listePieces = new List<string>();

            foreach (Piece Piece  in CommandeDAO.getPieces())
            {
                _listePieces.Add(Piece.Nom);
            }

            List<LigneCommande> _customers = null;
            List<Commande> _bondecommande = CommandeDAO.getCommandes();

            LigneCommandes = CollectionViewSource.GetDefaultView(_customers);
            Unites = CollectionViewSource.GetDefaultView(_unites);
            Commandes = CollectionViewSource.GetDefaultView(_bondecommande);
            PiecesAutocomplete = CollectionViewSource.GetDefaultView(_listePieces);



        }
         
    }
}
