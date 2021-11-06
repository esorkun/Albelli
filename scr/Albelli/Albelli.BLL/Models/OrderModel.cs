using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albelli.BLL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public decimal RequiredBinWidth { get; private set; }
        public virtual ICollection<OrderItemModel> OrderItem { get; set; }
        public OrderModel()
        {

        }

        public void CalculateRequiredBinWidth()
        {
            decimal binWidth = 0;

            // check if the same product added multiple times
            var orderItemsGroupByProductType = this.OrderItem.GroupBy(x => x.ProductType);

            foreach (var orderItems in orderItemsGroupByProductType)
            {
                foreach (var item in orderItems)
                {
                    if (item.Product.StackabilityLimit == 1)
                        binWidth += item.Product.Width * item.Quantity;
                    else
                    {
                        // effect of the Stackable Products on RequiredBinWidth
                        int remainder;
                        int quotient = Math.DivRem(item.Quantity, item.Product.StackabilityLimit, out remainder);

                        binWidth += item.Product.Width * quotient;

                        if (0 != remainder)
                            binWidth += item.Product.Width;
                    }
                }
                    
            }

            this.RequiredBinWidth = binWidth;
        }
    }
}
