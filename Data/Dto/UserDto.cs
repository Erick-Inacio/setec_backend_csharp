namespace SetecBackendCSharp.Data.Dto
{
  public class UserDto
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