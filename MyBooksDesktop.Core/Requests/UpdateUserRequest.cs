namespace MyBooksDesktop.Core.Requests;

public class UpdateUserRequest
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string? Name { get; set; }
    
    public string? SurName { get; set; }
}