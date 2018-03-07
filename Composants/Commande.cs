using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composants
{
    [Serializable]
    public class Commande
    {
        public Commande()
        {
        }
        public Commande(string nom)
        {
            Nom = nom;
            DateCreation = DateTime.Now;
        }


        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual List<LigneCommande> LigneCommandes { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateEdition { get; set; }
        public DateTime? DatePrevision { get; set; }
        
        public override string ToString()
        {
            return Nom + " créée le " + DateCreation.ToString();
        }

    }
}
