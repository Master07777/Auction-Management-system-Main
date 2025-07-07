using Factory.DatabaseLayer.Context;
using Factory.DatabaseLayer.Dto;
using Factory.DatabaseLayer.Services;
using Factory.DatabaseLayer.Services.Interface.cs;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductService _productService;
        private readonly OnlineAuctionDbContext _DbContext;
        public ProductController(OnlineAuctionDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]

        public ActionResult<IEnumerable<GetProductDto>> GetAllProducts()
        {
            var Services = new ProductService(_DbContext);
            var products = Services.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<GetProductDto> GetById([FromRoute] int id)
        {
            var Services = new ProductService(_DbContext);
            var product = Services.GetById(id);
            if (product == null)
            {
                return BadRequest("Product with this Id does not exists");
            }
            return Ok(product);
        }

        [HttpPost]

        public ActionResult AddProduct([FromBody] InputProductDto AddProduct)
        {
            var Services = new ProductService(_DbContext);
            Services.Add(AddProduct);
            return Ok("Product added successfully");

            // CreatedAtAction(nameof(GetAllProducts), new { id = AddProduct.Id }, AddProduct);
        }

        [HttpPut("{id}")]

        public ActionResult UpdateProductDetails([FromRoute] int id, [FromBody] InputProductDto UpdateProduct)
        {
            var Services = new ProductService(_DbContext);
            var product = Services.UpdateDetails(id, UpdateProduct);
            if (product == null)
            {
                return BadRequest("Product Id does not exists");
            }

            return Ok("Product Details Updated Successfully");
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var Services = new ProductService(_DbContext);
            var product = Services.Delete(id);
            if (product == null)
            {
                return BadRequest("Invalid Input Id");
            }
            return Ok("Product Deleted Successfully");
        }


    }
}
