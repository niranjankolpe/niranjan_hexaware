using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Orders
    {
        private int OrderID;
        private int CustomerID;
        private DateTime OrderDate;
        private int TotalAmount;

        internal int _OrderID { get; set; }

        internal int _CustomerID { get; set; }

        internal DateTime _OrderDate { get; set; }

        internal int _TotalAmount { get; set; }
    }
}
