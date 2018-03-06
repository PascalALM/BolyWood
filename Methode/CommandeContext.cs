using Composants;
using System.Data.Entity;

namespace Methode
{
    public class CommandeContext : DbContext
    {
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<LigneCommande> LigneCommandes { get; set; }
    }
}
