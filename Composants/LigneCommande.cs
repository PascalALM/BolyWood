namespace Composants
{
    public class LigneCommande
    {
        public int Id { get; set; }
        public int RefCommande { get; set; }
        public virtual Commande Commande { get; set; }
        public int RefPiece { get; set; }
        public virtual Piece Piece { get; set; }
        public float Quantite { get; set; }
        public string Unite { get; set; }


    }
}
