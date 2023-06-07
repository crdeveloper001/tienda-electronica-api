using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Services;

namespace tienda_electronica_api_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _service;
    
        public ProductsController(ProductsService productsService,AppLogsService appLogsService)
        {
            this._service = productsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await _service.GetProductos();
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<Products>> GetOneProduct(string name)
        {
            return await _service.SearchProduct(name);
        }

        [HttpPost]
        public async Task<string> PostProduct(Products product)
        {
            return await _service.CreateProduct(product);
        }
        [HttpPut]
        public async Task<string> PutProduct(Products update)
        {
            return await _service.UpdateProduct(update);
        }

        [HttpDelete]
        public async Task<string> DeleteProduct(string id)
        {
            return await _service.DeleteProduct(id);
        }
    }
}
