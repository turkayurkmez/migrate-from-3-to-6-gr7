using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangesInCSharp
{
    public struct Address
    {
        /*
         * 1. init kelimesini struct içinde kullanabiliyorum
         * 2. Parametresiz constructor yazabiliyorum!
         */
        public Address()
        {
            City = "İstanbul";
            Name = "[Bilinmiyor]";
        }
        public string Name { get; set; }

        public string City { get; init; }
    }


    public record struct Point(int X, int Y);
}
