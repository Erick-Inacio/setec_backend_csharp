using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace setec_backend_csharp.Models.Core
{
  public class User
  {
    public int Id { get; set; }

    public string? Uid { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public Relationship Relationship { get; set; }

    public Role Role { get; set; }

    public string? Ra { get; set; }
  }
}
