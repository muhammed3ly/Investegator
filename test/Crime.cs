using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
   public class Crime
   {
        public int id; 
        public string description;
        public string crime_status;
        public string crime_location;
        public string officerid;
        public string crimetype;
        public List<Item> items;
        public List<string> involved_people;
        public List<bool> Evidence;
        public List<bool> Motivation;
        public List<string> locacrime; 
        public List<string> imglocation;
        public Crime(){}
        public Crime(int stid, string des, string stat, string loc, string officer, string type, List<Item> i, List<string> peid, List<bool> mot, List<bool> evd, List<string> img, List<string> loca)
        {
            id = stid;
            description = des;
            crime_status = stat;
            crime_location = loc;
            officerid = officer;
            crimetype = type;
            items = i;
            involved_people = peid;
            imglocation = img;
            Evidence = evd;
            Motivation = mot;
            locacrime = loca;
        }
   }
}
