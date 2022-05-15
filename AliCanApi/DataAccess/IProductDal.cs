using AliCanApi.Entities;
using AliCanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.DataAccess
{
 public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductModel> GetProductModelsDetails();
        

    }
}
