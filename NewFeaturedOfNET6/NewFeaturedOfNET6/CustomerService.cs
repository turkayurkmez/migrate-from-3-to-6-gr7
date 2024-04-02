using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturedOfNET6
{
    public class CustomerService
    {
        public List<Customer> GetCustomers()
        {
            return new()
            {
                new(){ Name="Halkbank", Budget = 35000000, Country="Türkiye"},
                new(){ Name="Ülker", Budget = 15000000, Country="Türkiye"},

                new(){ Name="Samsung", Budget = 100000000, Country="Kore"},
                  new(){ Name="Microsoft", Budget = 100000000, Country="Amerika"},
                new(){ Name="BT Akademi", Budget = 500000, Country="Türkiye"},
            };


        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }

        public string Country { get; set; }
        public DateOnly SubscriptionDate { get; set; }
        public TimeOnly MaxDuration { get; set; }


    }
}
