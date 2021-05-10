using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Assemblage
    {
        private string nom;
        private string grandeur;
        private string cadre;
        private string guidon;
        private string freins;
        private string selle;
        private string derailleuravant;
        private string derailleurarriere;
        private string roueavant;
        private string rouearriere;
        private string reflecteur;
        private string pedalleur;
        private string ordinateur;
        private string panier;

        public Assemblage(string nom, string grandeur, string cadre, string guidon, string freins, string selle, string derailleuravant , string derailleurarriere, string roueavant, string rouearriere,string reflecteur, string pedalleur,string ordinateur,string panier)
        {
            this.nom = nom;
            this.grandeur = grandeur;
            this.cadre = cadre;
            this.guidon = guidon;
            this.freins = freins;
            this.selle = selle;
            this.derailleuravant = derailleuravant;
            this.derailleurarriere = derailleurarriere;
            this.roueavant = roueavant;
            this.rouearriere = rouearriere;
            this.reflecteur = reflecteur;
            this.pedalleur = pedalleur;
            this.ordinateur = ordinateur;
            this.panier = panier;
        }

        public string Nom
        {
            get { return this.nom; }
        }

        public string Grandeur
        {
            get { return this.grandeur; }
        }

        public string Cadre
        {
            get { return this.cadre; }
        }

        public string Guidon
        {
            get { return this.guidon; }
        }

        public string Freins
        {
            get { return this.freins; }
        }

        public string Selle
        {
            get { return this.selle; }
        }

        public string Derailleuravant
        {
            get { return this.derailleuravant; }
        }

        public string Derailleurarriere
        {
            get { return this.derailleurarriere; }
        }

        public string Roueavant
        {
            get { return this.roueavant; }
        }

        public string Rouearriere
        {
            get { return this.rouearriere; }
        }

        public string Reflecteur
        {
            get { return this.reflecteur; }
        }

        public string Pedalleur
        {
            get { return this.pedalleur; }
        }

        public string Ordinateur
        {
            get { return this.ordinateur; }
        }

        public string Panier
        {
            get { return this.panier; }
        }

        /// <summary>
        /// Creation du string des boissons
        /// </summary>
        public override string ToString()
        {
            return this.Nom + " " + this.Grandeur + " " + this.Cadre + " " + this.Guidon + " " + this.Freins + " " + this.Selle + " " + this.Derailleuravant + " " + this.Derailleurarriere + " " + this.Roueavant + " " + this.Rouearriere + " " + this.Reflecteur + " " + this.Pedalleur + " " + this.Ordinateur + " " + this.Panier;
        }
    }
}
