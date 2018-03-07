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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<CommandeContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<LigneCommande> LignesCommande { get; set; }
    }
}
