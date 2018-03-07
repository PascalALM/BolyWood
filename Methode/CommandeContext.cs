using Composants;
using System.Data.Entity;

namespace Methode
{

    public class CommandeContext : DbContext
    {
        public CommandeContext() : base("bolywood") {

            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;
        }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<LigneCommande> LignesCommande { get; set; }
    }
}
