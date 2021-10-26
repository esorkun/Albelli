using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal RequiredBinWidth { get; internal set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {

        }

        public void CalculateRequiredBinWidth()
        {
            decimal binWith = 0;

            var orderItemsGroupByProductType = this.OrderItems.GroupBy(x => x.ProductType);

            foreach (var orderItems in orderItemsGroupByProductType)
            {
                foreach (var item in orderItems)
                {
                    if (item.Product.StackabilityLimit == 1)
                        binWith += item.Product.Width * item.Quantity;
                    else
                    {
                        int remainder;
                        int quotient = Math.DivRem(item.Quantity, item.Product.StackabilityLimit, out remainder);

                        binWith += item.Product.Width * quotient;

                        if (0 != remainder)
                            binWith += item.Product.Width;
                    }
                }
                    
            }

            this.RequiredBinWidth = binWith;
        }
    }
}
