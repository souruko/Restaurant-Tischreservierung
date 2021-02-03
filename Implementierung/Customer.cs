using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tischreservierung
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public string Phonenumber { get; set; }
        public string EMain { get; set; }

        public Customer(string Name, int CustomerID, string Phonenumber, string EMail)
        {
            this.Name = Name;
            this.CustomerID = CustomerID;
            this.Phonenumber = Phonenumber;
            this.EMain = EMain;
        }
    }
}
