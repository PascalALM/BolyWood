using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composants
{
    public class Commande
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Piece> pieces { get; set; }
        public DateTime Date_creation { get; set; }
        public DateTime Date_edition { get; set; }
        public DateTime Date_prevision { get; set; }
        public DateTime Date_prev { get; set; }
        

    }
}
