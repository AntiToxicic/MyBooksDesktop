namespace MyBooksDesktop.Core.Models;

public class User
{
    public uint Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string? Name { get; set; }
    
    public string? SurName { get; set; }
}