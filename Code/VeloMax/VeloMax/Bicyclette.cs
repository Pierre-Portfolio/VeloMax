using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class Bicyclette
    {
        private int idbicy;
        private string nom;
        private string grandeur;
        private int prixbicy;
        private string ligneproduit;
        private DateTime dateintrobicy;
        private DateTime datediscontinuationbicy;


        public Bicyclette(int idbicy, string nom, string grandeur, int prixbicy, string ligneproduit, DateTime dateintrobicy, DateTime datediscontinuationbicy)
        {
            this.idbicy = idbicy;
            this.nom = nom;
            this.grandeur = grandeur;
            this.prixbicy = prixbicy;
            this.ligneproduit = ligneproduit;
            this.dateintrobicy = dateintrobicy;
            this.datediscontinuationbicy = datediscontinuationbicy;
        }

        public int Idbicy
        {
            get { return this.idbicy; }
        }

        public string Nom
        {
            get { return this.nom; }
        }

        public string Grandeur
        {
            get { return this.grandeur; }
        }

        public int Prixbicy
        {
            get { return this.prixbicy; }
        }

        public string Ligneproduit
        {
            get { return this.ligneproduit; }
        }

        public DateTime Dateintrobicy
        {
            get { return this.dateintrobicy; }
        }

        public DateTime Datediscontinuationbicy
        {
            get { return this.datediscontinuationbicy; }
        }


        public override string ToString()
        {
            return this.idbicy + " " + this.nom + " " + this.grandeur + " " + this.prixbicy + " " + this.ligneproduit + " " + this.dateintrobicy + " " + this.datediscontinuationbicy;
        }

    }
}
