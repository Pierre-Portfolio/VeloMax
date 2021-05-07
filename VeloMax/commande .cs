using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    class commande
    {
        private int numcommande;
        private DateTime datecommande;
        private string adrlivraison;
        private DateTime datelivraison;
        private int idclient;

        public commande(int numcommande, DateTime datecommande, string adrlivraison, DateTime datelivraison, int idclient)
        {
            this.numcommande = numcommande;
            this.datecommande = datecommande;
            this.adrlivraison = adrlivraison;
            this.datelivraison = datelivraison;
            this.idclient = idclient;
        }

        public int Numcommande
        {
            get { return this.numcommande; }
        }

        public DateTime Datecommande
        {
            get { return this.datecommande; }
        }

        public string Adrlivraison
        {
            get { return this.adrlivraison; }
        }

        public DateTime Datelivraison
        {
            get { return this.datelivraison; }
        }

        public int Idclient
        {
            get { return this.idclient; }
        }

        public override string ToString()
        {
            return this.numcommande + " " + this.datecommande + " " + this.adrlivraison + " " + this.idclient;
        }
    }
}
