using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
   public  class Crimetype
    {
        public string typename;
        public string description;
        public int crimetypeid;
        public Crimetype() { }
        public Crimetype(int id, string type, string desc)
        {
            typename = type;
            crimetypeid = id;
            description = desc;
        }
    }
}
