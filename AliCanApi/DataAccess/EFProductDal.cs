using AliCanApi.Entities;
using AliCanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.DataAccess
{
    public class EFProductDal : EfEntityRepositoryBase<Product, NortWindContext>, IProductDal
    {
        public List<ProductModel> GetProductModelsDetails()
        {
            using (NortWindContext context = new NortWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductModel
                             { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitPrice = p.UnitPrice };
                return result.ToList();

            }
        }
    }
}