using MyBooksDesktop.Core.Models.Enums;

namespace MyBooksDesktop.Core.Models;

public class Book
{
    public Book(uint userId, string title)
    {
        UserId = userId;
        Title = title;
    }

    public uint Id { get; set; }
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public string? Author { get; set; }
    
    public uint UserId { get; set; }
}