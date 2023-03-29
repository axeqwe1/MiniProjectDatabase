using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectDatabase.asset.lib
{
    public class SaleList
    {
        string name;
        string detail;
        string size;
        double price;
        int qty;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        public string DETAIL
        {
            get { return detail; }
            set { detail = value; }
        }
        public string SIZE
        {
            get { return size; }
            set { size = value; }
        }
        public double PRICE
        {
            get { return price; }
            set { price = value; }
        }
        public int QTY
        {
            get { return qty; }
            set { qty = value; }
        }
    }
}
