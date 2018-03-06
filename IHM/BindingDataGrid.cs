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


        public BindingDataGrid()
        {
            var _customers = new List<LigneCommande>();

            LigneCommandes = CollectionViewSource.GetDefaultView(_customers);



        }
         
    }
}
