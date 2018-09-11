using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace test
{
    [Serializable]
    public class officer_info
    {
        public string offId { get; set; }
        public string name { get; set; }
        public string birth { get; set; }
        public string mar { get; set; }
        public string gen { get; set; }
        public string pss { get; set; }
        public string add { get; set; }
        public string img { get; set; }
        public List<string> crimID;
        public List<string> closedCrime;
        public officer_info()
        {
            crimID = new List<string>();
            closedCrime = new List<string>();

        }
        public officer_info(string nam, string ofId, string birt, string ps, string ge, string m, string mg, string ad)
        {
            offId = ofId;
            name = nam;
            birth = birt;
            pss = ps;
            mar = m;
            gen = ge;
            add = ad;
            img = mg;
            crimID = new List<string>();
            closedCrime = new List<string>();

        }
        public void updateInfo(string nam, string ofId, string birt, string ps, string ge, string m, string mg, string ad)
        {
            offId = ofId;
            name = nam;
            birth = birt;
            pss = ps;
            mar = m;
            gen = ge;
            add = ad;
            img = mg;
        }
    }
}
