using System;
using System.Collections.Generic;
using System.Text;

namespace Z2_DAPPER
{
    class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetails> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetails>();
        }
    }
}
