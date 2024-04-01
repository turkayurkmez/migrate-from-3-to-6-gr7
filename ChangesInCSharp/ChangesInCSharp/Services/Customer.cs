using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangesInCSharp.Services
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerAddress Address { get; set; }


        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public string Extension { get; set; }

        public DateOnly CreatedDate { get; set; }




    }

    public class CustomerAddress
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
