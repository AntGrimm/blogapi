using System;

namespace blogapi.Models
{
  public class Comment
  {
    public int Id { get; set; }
    // public string Comment { get; set; }
    public string Author { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.Now;
  }
}