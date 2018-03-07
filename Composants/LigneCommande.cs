using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composants
{
    public class LigneCommande : Model
    {
        [Required]
        [ForeignKey("Commande")]
        public int RefCommande { get; set; }
        public virtual Commande Commande { get; set; }

        [Required]
        [ForeignKey("Piece")]
        public int RefPiece { get; set; }
        public virtual Piece Piece { get; set; }
        [Required]
        public float Quantite { get; set; }
        public string Unite { get; set; }


    }
}
