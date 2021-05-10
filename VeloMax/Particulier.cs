using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Particulier
    {
        private int idparticulier;
        private string nomclient;
        private string prenomclient;
        private int idclient;
        private int idfidelio;

        public Particulier(int idparticulier, string nomclient, string prenomclient, int idclient, int idfidelio)
        {
            this.idparticulier = idparticulier;
            this.nomclient = nomclient;
            this.prenomclient = prenomclient;
            this.idclient = idclient;
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

        public int Idclient
        {
            get { return this.idclient; }
        }

        public int Idfidelio
        {
            get { return this.idfidelio; }
        }

        public override string ToString()
        {
            return this.idparticulier + " " + this.nomclient + " " + this.prenomclient + " " + this.idclient + " " + this.idfidelio;
        }

    }
}
