using System;
using BlogApi.Models;

namespace blogapi.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.Now;
    public int OhSnaps { get; set; }

    public int BlogId { get; set; }

    public Blog Blog { get; set; }
  }
}