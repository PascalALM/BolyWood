﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methode
{
    class BonCommandeDAO
    { 

        public string getBonCommande(int id)
        {
            //this.msg = new msg;
            //this.msg.data = new object[1];
            //this.msg.data[0] = (object)"SELECT id FROM PERSONNE WHERE login = '"+ login + "' AND psd = '"+ pwd + "';";
            return "SELECT * FROM BON_COMMANDE WHERE id = " + id + ";";
            
        }
        public string getBonCommandes()
        {
            //this.msg = new msg;
            //this.msg.data = new object[1];
            //this.msg.data[0] = (object)"SELECT id FROM PERSONNE WHERE login = '"+ login + "' AND psd = '"+ pwd + "';";
            return "SELECT * FROM BON_COMMANDE ORDER BY id DESC";
            
        }
    }
}
