using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composants
{
    public class LignePiece
    {
        public int Id { get; set; }
        public int RefCommande { get; set; }
        public int RefPiece { get; set; }
        public float Quantite { get; set; }
        public string Unite { get; set; }


    }
}
