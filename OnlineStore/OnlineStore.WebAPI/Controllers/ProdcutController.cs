using OnlineStore.Core;
using OnlineStore.Core.Entities;
using OnlineStore.Service.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineStore.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/product")]
    public class ProdcutController : ApiController
    {
        private readonly ProductService _productService;
        public ProdcutController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost]
        [Route("SaveProduct")]
        public async Task<HttpResponseMessage> SaveProduct(Product product)
        {
            try
            {
                var newProduct = await _productService.SaveProductAsync(product);
                return Request.CreateResponse(HttpStatusCode.OK, newProduct);
            }
            catch (OnlineStoreBusinessException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

     

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<HttpResponseMessage> DeleteProduct(Product product)
        {
            await _productService.DeleteAsync(product);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public  HttpResponseMessage GetAllProducts()
        {
            var products =  _productService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }


    }
}
