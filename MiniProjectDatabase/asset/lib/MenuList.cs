using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectDatabase.asset.lib
{
    
    class MenuList
    {
        string menuid;
        string sizeid;
        string name;
        string detail;
        double price;
        string size;
        string type;
        string picture;
        
        public string MenuId
        {
            get { return menuid; }
            set { menuid = value; }
        }
        public string SizeID
        {
            get { return sizeid; }
            set { sizeid = value; }
        }
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string MSize
        {
            get { return size; }
            set { size = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
