using Composants;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methode
{
    public class CommandeDAO
    {

        //public static List<LigneCommande> getLignesCommandeByCommande(Commande c)
        //{

        //    using (var db = new CommandeContext())
        //    {
        //        return db.LignesCommande
        //            .Where(lc => lc.Commande == c)
        //            .Include("Piece")
        //            .ToList();
        //    }

        //}

        public static Commande getCommande(int id)
        {

            using (var db = new CommandeContext())
            {
                return db.Commandes
                    .Where(c => c.Id == id)
                    .Include(c => c.LignesCommande.Select(lc => lc.Piece))
                    .SingleOrDefault();
            }

        }
        public static List<Commande> getCommandes()
        {
            using (var db = new CommandeContext())
            {
                return db.Commandes
                    .Include(c => c.LignesCommande.Select(lc => lc.Piece))
                    .ToList();
            }
        }
        public static Piece getPieceByName(string name)
        {

            using (var db = new CommandeContext())
            {
                return db.Pieces
                    .Where(p => p.Nom == name)
                    .FirstOrDefault();
            }

        }
        public static List<Piece> getPieces()
        {
            using (var db = new CommandeContext())
            {
                return db.Pieces.ToList();
            }
        }
        public static LigneCommande insertLigneCommande(LigneCommande obj) 
        {
            using (var db = new CommandeContext())
            {
                var table = db.Set(typeof(LigneCommande));
                try
                {
                    db.Entry(obj.Commande).State = EntityState.Unchanged;
                    db.Entry(obj.Piece).State = EntityState.Unchanged;

                } catch(Exception e)
                {

                }

                table.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public static T insertObject<T>(T obj) where T : Model
        {
            using(var db = new CommandeContext())
            {
                var table = db.Set(obj.GetType());
                //if(obj.GetType() == typeof(LigneCommande) )
                //{
                //    // use the following statement so that City won't be inserted
                //    db.Entry(obj.Commande).State = EntityState.Unchanged;
                //}
                table.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public static T updateObject<T>(T obj) where T : Model
        {
            using(var db = new CommandeContext())
            {
                var table = db.Set(obj.GetType());

                var original = table.Find(obj.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(obj);
                    db.SaveChanges();

                    return obj;
                }

                return null;
            }
        }
    }
}
