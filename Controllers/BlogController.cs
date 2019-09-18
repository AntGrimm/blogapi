using System.Linq;
using blogapi;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogController : ControllerBase
  {
    private DatabaseContext context;

    public BlogController()
    {
      this.context = new DatabaseContext();
    }

    [HttpPost]
    public ActionResult<Blog> CreateEntry([FromBody]Blog entry)
    {
      // 1. reference the database
      //var context = new DatabaseContext();
      // 2. do the thing
      context.Blogs.Add(entry);
      // 3. save the thing
      context.SaveChanges();
      return entry;
    }

    // [HttpGet]
    // public ActionResult<IEnumberable<Blog>> GetAllBlogs()
    // {
    //   // 1. reference the database
    //   var context = new DatabaseContext();
    //   // 2. do the thing
    //   var blogs = context.Blogs.OrderByDescending(blogapi => blogapi.DateCreated);
    //   // 3. return the thing
    //   return blogs.ToList();
    // }

    [HttpGet("{id}")]
    public ActionResult<Blog> GetOneBlog(int id)
    {
      //var context = new DatabaseContext();
      var blog = context.Blogs.FirstOrDefault(b => b.Id == id);
      if (blog == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(blog);
      }
    }
  }
}