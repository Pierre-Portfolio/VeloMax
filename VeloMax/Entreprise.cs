using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Entreprise
    {
        private string identre;
        private string nomentre;
        private float remiseentre;
        private int idclient;

        public Entreprise(string identre, string nomentre, float remiseentre, int idclient)
        {
            this.identre = identre;
            this.nomentre = nomentre;
            this.remiseentre = remiseentre;
            this.idclient = idclient;
        }

        public string Identre
        {
            get { return this.identre; }
        }

        public string Nomentre
        {
            get { return this.nomentre; }
        }

        public float Remiseentre
        {
            get { return this.remiseentre; }
        }

        public int Idclient
        {
            get { return this.idclient; }
        }

        public override string ToString()
        {
            return this.identre + " " + this.nomentre + " " + this.remiseentre + " " + this.idclient;
        }
    }
}
