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
    public class ProductsOrdersController : ControllerBase
    {
        private readonly ProductsOrdersService _service;

        public ProductsOrdersController(ProductsOrdersService service)
        {
            this._service = service;
            
        }

        [HttpGet]
        public async Task<IEnumerable<ProductOrders>> GetAllProductsOrders()
        {
            return await _service.GetProductOrders();
        }
        [HttpPost]
        public async Task<string> PostProductOrder(ProductOrders order)
        {
           return await _service.CreateProductOrder(order);

        }
        [HttpPut]
        public async Task<string> PutProductOrder(ProductOrders update)
        {
            return await _service.UpdateProductOrder(update);
            
        }
    }
}
