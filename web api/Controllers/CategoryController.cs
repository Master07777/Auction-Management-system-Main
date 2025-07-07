using Factory.DatabaseLayer.Context;
using Factory.DatabaseLayer.Dto;
using Factory.DatabaseLayer.Services;
using Factory.DatabaseLayer.Services.Interface.cs;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly CategoryService  _categoryService;
        private  readonly OnlineAuctionDbContext _DbContext;
        public CategoryController(OnlineAuctionDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        //var Services = new CategoryService(_DbContext);

        [HttpGet]
        public ActionResult<IEnumerable<GetCategoryDto>> GetAllCategory()
        {
            var Services = new CategoryService(_DbContext);
            var categories = Services.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<GetCategoryDto> GetCategoryById([FromRoute] int id)
        {
            var Services = new CategoryService(_DbContext);
            var category = Services.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] InputCategoryDto AddCategory)
        {
            var Services = new CategoryService(_DbContext);
            Services.Add(AddCategory);
            return Ok("Category added successfully");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategoryDetails([FromRoute] int id,[FromBody] InputCategoryDto UpdateCategory)
        {
            var Services = new CategoryService(_DbContext);
            var category = Services.UpdateDetails(id, UpdateCategory);
            if (category == null)
            {
                return BadRequest("Category Id does not exists");
            }
            return Ok("Category Details Updated Successfully");
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteCategory([FromRoute] int id)
        {
            var Services = new CategoryService(_DbContext);
            var category = Services.Delete(id);
            if (category == null)
            {
                return BadRequest("Category Id does not exists");
            }
            return Ok("Category Deleted Successfully");
        }
    }
}
