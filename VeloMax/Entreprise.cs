using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Entreprise : clientele
    {
        private int identre;
        private string nomentre;
        private float remiseentre;

        public Entreprise(int idclient, int identre, string nomentre, float remiseentre, string rueclient, string codepostaleclient, string provinceclient, string villeclient) : base ( idclient,  rueclient,  codepostaleclient,  provinceclient,  villeclient)
        {
            this.identre = identre;
            this.nomentre = nomentre;
            this.remiseentre = remiseentre;
        }

        public int Identre
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

        public override string ToString()
        {
            return base.ToString() + this.identre + " " + this.nomentre + " " + this.remiseentre + " ";
        }
    }
}
