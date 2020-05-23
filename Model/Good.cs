using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Good
    {
        public string name;
        public int id;
        public int price;
        public bool availbl;

        public Good() { }

        public Good(int id, string name, int price, bool availbl)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.availbl = availbl;
        }
    }
}
