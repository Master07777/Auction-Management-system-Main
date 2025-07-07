using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Factory.DatabaseLayer.Context;
using Factory.DatabaseLayer.Models;
using Factory.Services;
namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly OnlineAuctionDbContext dbContext;
        
        //constructor
        public UserController(OnlineAuctionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //API TO GET ALL USERS
        [HttpGet]
        public IActionResult GetAll()
        {
            UserServices temp = new UserServices(dbContext);
            List<User> result=temp.GetAllUser();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        
        public IActionResult GetById( int id)
        {
            return Ok();
        }


    } 
}
