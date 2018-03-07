using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composants
{
    public class LigneCommande : Model
    {
        [Required]
        //[ForeignKey("Commande")]
        //public int RefCommande { get; set; }
        public Commande Commande { get; set; }

        [Required]
        public Piece Piece { get; set; }

        [Required]
        public float Quantite { get; set; }
        public string Unite { get; set; }

        public override string ToString()
        {
            return "Pièce : " + Piece.Nom + " | Quantité : " + Quantite + " " + Unite;
        }

    }
}
