using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.Entities
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public short UnitsInStock { get; set; }


    }
}
