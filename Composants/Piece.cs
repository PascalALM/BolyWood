using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composants
{
    public class Piece : Model
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public double PrixUnitaire { get; set; }
        public virtual ICollection<LigneCommande> LignesCommande { get; set; }


        public override string ToString()
        {
            return Nom;
        }

        public Piece(string Nom)
        {
            this.Nom = Nom;
        }

        public Piece()
        {

        }


    }
}
