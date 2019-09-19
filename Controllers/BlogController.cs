using System.Linq;
using blogapi;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using blogapi.Models;
using blogapi.Controllers.ViewModels;

namespace BlogApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogController : ControllerBase
  {
    private DatabaseContext context;

    public BlogController(DatabaseContext _context)
    {
      this.context = _context;

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

    [HttpGet]
    public ActionResult<IEnumerable<Blog>> GetAllBlogs()
    {
      // 1. reference the database
      var context = new DatabaseContext();
      // 2. do the thing
      var blogs = context.Blogs.OrderByDescending(blogapi => blogapi.DateCreated);
      // 3. return the thing
      return blogs.ToList();
    }

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

    [HttpPut("{id}")]
    public ActionResult<Blog> UpdateBlog(int id, [FromBody] Blog newDetails)
    {
      if (id != newDetails.Id)
      {
        return BadRequest();
      }
      context.Entry(newDetails).State = EntityState.Modified;
      context.SaveChanges();
      return newDetails;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBlog(int id)
    {
      var blog = context.Blogs.FirstOrDefault(f => f.Id == id);
      if (blog == null)
      {
        return NotFound();
      }
      else
      {
        context.Blogs.Remove(blog);
        context.SaveChanges();
        return Ok(new DeleteResponse { Blog = blog });
      }
    }

    [HttpPost("{blogId}/comments")]
    public ActionResult<Comment> CreateComment(int blogId, [FromBody]Comment comment)
    {
      // var blog = context.Blogs.FirstOrDefault(f => f.Id == blogId);
      // if (blog == null)
      // {
      //   return NotFound();
      // }
      // else
      // {
      comment.BlogId = blogId;
      context.Comments.Add(comment);
      context.SaveChanges();
      return Ok(new { });
    }
  }
}