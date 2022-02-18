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

        public Assemblage()
        {
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Grandeur
        {
            get { return this.grandeur; }
            set { this.grandeur = value; }
        }

        public string Cadre
        {
            get { return this.cadre; }
            set { this.cadre = value; }
        }

        public string Guidon
        {
            get { return this.guidon; }
            set { this.guidon = value; }
        }

        public string Freins
        {
            get { return this.freins; }
            set { this.freins = value; }
        }

        public string Selle
        {
            get { return this.selle; }
            set { this.selle = value; }
        }

        public string Derailleuravant
        {
            get { return this.derailleuravant; }
            set { this.derailleuravant = value; }
        }

        public string Derailleurarriere
        {
            get { return this.derailleurarriere; }
            set { this.derailleurarriere = value; }
        }

        public string Roueavant
        {
            get { return this.roueavant; }
            set { this.roueavant = value; }
        }

        public string Rouearriere
        {
            get { return this.rouearriere; }
            set { this.rouearriere = value; }
        }

        public string Reflecteur
        {
            get { return this.reflecteur; }
            set { this.reflecteur = value; }
        }

        public string Pedalleur
        {
            get { return this.pedalleur; }
            set { this.pedalleur = value; }
        }

        public string Ordinateur
        {
            get { return this.ordinateur; }
            set { this.ordinateur = value; }
        }

        public string Panier
        {
            get { return this.panier; }
            set { this.panier = value; }
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
