using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Particulier : clientele
    {
        private int idparticulier;
        private string nomclient;
        private string prenomclient;
        private int idfidelio;

        public Particulier(int idclient, int idparticulier, string nomclient, string prenomclient, int idfidelio, string rueclient, int codepostaleclient, string provinceclient, string villeclient) : base (idclient, rueclient, codepostaleclient, provinceclient, villeclient)
        {
            this.idparticulier = idparticulier;
            this.nomclient = nomclient;
            this.prenomclient = prenomclient;
            this.idfidelio = idfidelio;
        }

        public int Idparticulier
        {
            get { return this.idparticulier; }
        }

        public string Nomclient
        {
            get { return this.nomclient; }
        }

        public string Prenomclient
        {
            get { return this.prenomclient; }
        }

        public int Idfidelio
        {
            get { return this.idfidelio; }
        }

        public override string ToString()
        {
            return base.ToString() + this.idparticulier + " " + this.nomclient + " " + this.prenomclient + " "  + " " + this.idfidelio;
        }

    }
}
