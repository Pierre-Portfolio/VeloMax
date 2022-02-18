using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloMax
{
    public class ItemStock
    {
        private int iditemstock;
        private int idbicy;
        private string numpiece;


        public ItemStock(int iditemstock, int idbicy, string numpiece)
        {
            this.iditemstock = iditemstock;
            this.idbicy = idbicy;
            this.numpiece = numpiece;
        }

        public int Iditemstock
        {
            get { return this.iditemstock; }
        }

        public int Idbicy
        {
            get { return this.idbicy; }
        }

        public string Numpiece
        {
            get { return this.numpiece; }
        }

        public override string ToString()
        {
            return this.Iditemstock + " " + this.Idbicy + " " + this.Numpiece;
        }
    }
}
