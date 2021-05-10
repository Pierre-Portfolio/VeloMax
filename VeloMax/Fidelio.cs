using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Fidelio
    {
        private int idfidelio;
        private string descfidelio;
        private int cout;
        private int duree;
        private int rabais;

        public Fidelio(int idfidelio, string descfidelio, int cout, int duree, int rabais)
        {
            this.idfidelio = idfidelio;
            this.descfidelio = descfidelio;
            this.cout = cout;
            this.duree = duree;
            this.rabais = rabais;
        }
        public int Idfidelio
        {
            get { return this.idfidelio; }
        }

        public string Descfidelio
        {
            get { return this.descfidelio; }
        }

        public int Cout
        {
            get { return this.cout; }
        }

        public int Duree
        {
            get { return this.duree; }
        }

        public int Rabais
        {
            get { return this.rabais; }
        }

        public override string ToString()
        {
            return this.idfidelio + " " + this.descfidelio + " " + this.cout + " " + this.duree + " " + this.rabais;
        }

    }
}
