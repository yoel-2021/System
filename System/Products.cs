using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class Products
    {
        private int id;
        private string code;
        private string name;
        private string description;
        private double public_price;
        private int stock;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Public_price { get => public_price; set => public_price = value; }
        public int Stock { get => stock; set => stock = value; }
        
    }
}
