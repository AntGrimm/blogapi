using blogapi;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogController : ControllerBase
  {
    [HttpPost]
    public ActionResult<Blog> CreateEntry([FromBody]Blog entry)
    {
      // add entry to the database
      // 1. reference the database
      var context = new DatabaseContext();
      // 2. do the thing
      context.Blogs.Add(entry);
      // 3. save the thing
      context.SaveChanges();
      return entry;
    }
  }
}