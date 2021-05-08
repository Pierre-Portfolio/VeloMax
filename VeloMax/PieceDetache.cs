using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    class PieceDetache
    {
        private string numpiece;
        private string descpiece;
        private int numprodcatalogue;
        private int prixpiece;
        private DateTime dateintroprod;
        private DateTime datediscontprod;
        private int delaiapprovprod;
        private string siret;

        public PieceDetache(string numpiece,string descpiece,int numprodcatalogue, int prixpiece, DateTime dateintroprod, DateTime datediscontprod,int delaiapprovprod,string siret)
        {
            this.numpiece = numpiece;
            this.descpiece = descpiece;
            this.numprodcatalogue = numprodcatalogue;
            this.prixpiece = prixpiece;
            this.dateintroprod = dateintroprod;
            this.datediscontprod = datediscontprod;
            this.delaiapprovprod = delaiapprovprod;
            this.siret = siret;
        }

        public string Numpiece
        {
            get { return this.numpiece; }
        }

        public string Descpiece
        {
            get { return this.descpiece; }
        }

        public int Numprodcatalogue
        {
            get { return this.numprodcatalogue; }
        }

        public int Prixpiece
        {
            get { return this.prixpiece; }
        }

        public DateTime Dateintroprod
        {
            get { return this.dateintroprod; }
        }

        public DateTime Datediscontprod
        {
            get { return this.datediscontprod; }
        }

        public int Delaiapprovprod
        {
            get { return this.delaiapprovprod; }
        }

        public string Siret
        {
            get { return this.siret; }
        }

        public override string ToString()
        {
            return this.numpiece + " " + this.descpiece + " " + this.numprodcatalogue + " " + this.prixpiece + " " + this.dateintroprod + " " + this.datediscontprod + " " + this.delaiapprovprod + " " + this.siret;
        }
    }
}
