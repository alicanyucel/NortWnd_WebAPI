using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.Entities
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
