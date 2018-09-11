using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    [Serializable]
    public class involvedPeople
    {
        public string name { get; set; }
        public string personalID { get; set; }
        public string address { get; set; }
        public string birthDate { get; set; }
        public string nationality { get; set; }
        public string militaryStatus { get; set; }
        public string imagePath { get; set; }
        public string gender { get; set; }
        public string martialStatus { get; set; }
        public List<int> CrimeIDS { get; set; }
        public involvedPeople(string name, string ID, string Add, string BD, string NAT, string MS, string imgPath, string gen, string MRS)
        {
            this.name = name;
            this.personalID = ID;
            this.address = Add;
            this.nationality = NAT;
            this.militaryStatus = MS;
            this.martialStatus = MRS;
            this.imagePath = imgPath;
            this.gender = gen;
            this.CrimeIDS = new List<int>();
        }
        public involvedPeople()
        {
            this.CrimeIDS = new List<int>();
        }
    }
}
