using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    class Itemcmd
    {

        private string iditemscmd;
        private int quantite;
        private int iditemstock;
        private int numcommande;

        public Itemcmd(string iditemscmd, int quantite, int iditemstock, int numcommande)
        {
            this.iditemscmd = iditemscmd;
            this.quantite = quantite;
            this.iditemstock = iditemstock;
            this.numcommande = numcommande;
        }

        public string Iditemscmd
        {
            get { return this.iditemscmd; }
        }

        public int Quantite
        {
            get { return this.quantite; }
        }

        public int Iditemstock
        {
            get { return this.iditemstock; }
        }

        public int Numcommande
        {
            get { return this.numcommande; }
        }

        public string AfficherBoisson()
        {
            return this.Iditemscmd + " " + this.Quantite + " " + this.Iditemstock + " " + this.Numcommande;
        }
    }
}
