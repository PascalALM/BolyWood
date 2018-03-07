using Composants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methode
{
    public class CommandeDAO
    {

        public static Commande getCommande(int id)
        {

            using (var db = new CommandeContext())
            {
                return db.Commandes.Where(c => c.Id == id).SingleOrDefault();
            }

        }
        public static List<Commande> getCommandes()
        {
            using (var db = new CommandeContext())
            {
                return db.Commandes.ToList();
            }

        }
        public static List<Piece> getPieces()
        {
            using (var db = new CommandeContext())
            {
                return db.Pieces.ToList();
            }

        }
    }
}
