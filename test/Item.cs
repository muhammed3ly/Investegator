using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Item
    {
        public string itemname;
        public string itemdescription;
        public string date;
        public string PersonID;
        public Item() { }
        public Item(string name,string des,string d,string persid)
        {
            itemname = name;
            itemdescription = des;
            date = d;
            PersonID = persid;
        }
    }
}
