using BlogApi.Models;

namespace blogapi.Controllers.ViewModels
{
  public class DeleteResponse
  {
    public string Message { get; set; } = "Successfully deleted blog";

    public Blog Blog { get; set; }
  }
}