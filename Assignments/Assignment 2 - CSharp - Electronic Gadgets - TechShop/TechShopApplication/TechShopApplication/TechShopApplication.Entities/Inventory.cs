using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApplication
{
    internal class Inventory
    {
        private int InventoryID;
        private int ProductID;
        private int QuantityInStock;
        private DateTime LastStockUpdate;

        internal int _InventoryID { get; set; }

        internal int _ProductID { get; set; }

        internal int _QuantityInStock { get; set; }

        internal DateTime _LastStockUpdate { get; set; }
    }
}
