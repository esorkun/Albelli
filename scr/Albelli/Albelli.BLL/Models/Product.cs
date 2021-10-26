using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Models
{
    public class Product
    {
        internal int Id { get; set; }
        public string ProductType { get; set; }
        public decimal Width { get; set; }
        public int StackabilityLimit { get; set; }
        public Product()
        {

        }
    }
}
