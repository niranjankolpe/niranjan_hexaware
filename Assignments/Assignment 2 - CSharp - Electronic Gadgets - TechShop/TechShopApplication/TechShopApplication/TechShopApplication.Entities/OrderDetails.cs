using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class OrderDetails
    {
        private int OrderDetailID;
        private int OrderID;
        private int ProductID;
        private int Quantity;

        internal int _OrderDetailID { get; set; }

        internal int _OrderID { get; set; }

        internal int _ProductID { get; set; }

        internal int _Quantity { get; set; }
    }
}
