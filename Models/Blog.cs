using System;

namespace blogapi.Models
{
  public class Blog
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string ImageUrl { get; set; }
    public int OhSnaps { get; set; }
  }
}