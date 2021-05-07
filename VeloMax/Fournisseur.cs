using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    class Fournisseur
    {
        private string siret;
        private string nomentreprise;
        private string contact;
        private string adrfour;
        private string libellefourniseur;


        public Fournisseur(string siret, string nomentreprise, string contact, string adrfour,string libellefourniseur)
        {
            this.siret = siret;
            this.nomentreprise = nomentreprise;
            this.contact = contact;
            this.adrfour = adrfour;
            this.libellefourniseur = libellefourniseur;
        }

        public string Siret
        {
            get { return this.siret; }
        }

        public string Nomentreprise
        {
            get { return this.nomentreprise; }
        }

        public string Contact
        {
            get { return this.contact; }
        }

        public string Adrfour
        {
            get { return this.adrfour; }
        }

        public string Libellefourniseur
        {
            get { return this.libellefourniseur; }
        }

        public override string ToString()
        {
            return this.Siret + " " + this.Nomentreprise + " " + this.Contact + " " + this.Adrfour + " " + this.Libellefourniseur;
        }

    }
}
