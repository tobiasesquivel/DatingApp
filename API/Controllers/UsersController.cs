using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            List<AppUser> users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id:int}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            AppUser? user = context.Users.Find(id);

            return user != null ? user : NotFound();

        }
    }
}
