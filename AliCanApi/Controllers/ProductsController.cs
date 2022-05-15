using AliCanApi.DataAccess;
using AliCanApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.Controllers
{
    [Route("api/{controller}")]

    public class ProductsController : Controller
    {
        IProductDal _productDal;
        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody]Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("getproductsdetails")]
        public IActionResult GetProductsDetails()
        {
            try
            {
               var result= _productDal.GetProductModelsDetails();
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("delete/{productid}")]
        public IActionResult Delete(int productid)
        {
            try
            {
                _productDal.Delete(new Product {ProductId=productid});
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("post")]
        public IActionResult Post([FromBody]Product product)
        {
            // 201 data eklendi http kodu 200 basarılı
            try
            {
                _productDal.Add(product);
                return Ok(product);
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }
        [HttpGet("get")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();

            return Ok(products);
        }
        [HttpGet("get/{productid}")]
        public IActionResult Get(int productid)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductId == productid);
                if (product == null)
                {
                    return NotFound($"product id={productid}");
                }
                return Ok(product);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}