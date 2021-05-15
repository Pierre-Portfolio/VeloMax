using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class clientele
    {
        private int idclient;
        private string rueclient;
        private string codepostaleclient;
        private string provinceclient;
        private string villeclient;

        public clientele(int idclient, string rueclient, string codepostaleclient, string provinceclient, string villeclient)
        {
            this.idclient = idclient;
            this.rueclient = rueclient;
            this.codepostaleclient = codepostaleclient;
            this.provinceclient = provinceclient;
            this.villeclient = villeclient;
        }

        public int Idclient
        {
            get { return this.idclient; }
        }

        public string Rueclient
        {
            get { return this.rueclient; }
        }

        public string Codepostaleclient
        {
            get { return this.codepostaleclient; }
        }

        public string Provinceclient
        {
            get { return this.provinceclient; }
        }

        public string Villeclient
        {
            get { return this.villeclient; }
        }

        public override string ToString()
        {
            return this.idclient + " " + this.rueclient + " " + this.codepostaleclient + " " + this.provinceclient + " " + this.villeclient;
        }

    }
}
