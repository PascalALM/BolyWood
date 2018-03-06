using Composants;
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


        public BindingDataGrid()
        {


            List<string> _unites = new List<string> { "Piece", "Lot", "Gramme", "KiloGramme" };

            var _customers = new List<LigneCommande>();

            LigneCommandes = CollectionViewSource.GetDefaultView(_customers);
            Unites = CollectionViewSource.GetDefaultView(_unites);



        }
         
    }
}
