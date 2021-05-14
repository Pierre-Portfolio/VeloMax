using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Entreprise : clientele
    {
        private string identre;
        private string nomentre;
        private float remiseentre;

        public Entreprise(string identre, string nomentre, float remiseentre, int idclient, string rueclient, int codepostaleclient, string provinceclient, string villeclient) : base ( idclient,  rueclient,  codepostaleclient,  provinceclient,  villeclient)
        {
            this.identre = identre;
            this.nomentre = nomentre;
            this.remiseentre = remiseentre;
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

        public override string ToString()
        {
            return base.ToString() + this.identre + " " + this.nomentre + " " + this.remiseentre + " ";
        }
    }
}
