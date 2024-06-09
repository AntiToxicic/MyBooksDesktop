using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.BookModels;

public class EditBookViewModel : INotifyPropertyChanged
{
    private readonly IBookService _bookService;
    
    private Book? _selectedBook;
    private string? _title;
    private string? _author;
    private string? _description;
    
    public string? Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }
    
    public string? Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged(nameof(Author));
        }
    }
    
    public string? Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public ICommand UpdateBookCommand { get; set; }

    public EditBookViewModel(IBookService bookService)
    {
        _bookService = bookService;
        UpdateBookCommand = new RelayCommand(EditBook);
    }

    public void Initialize(Book? book)
    {
        _selectedBook = book;
        
        if(book is null) return;
        
        Title = book.Title;
        Author = book.Author;
        Description = book.Description;
    }
    
    public async void EditBook()
    {
        if (Title is not null && _selectedBook is not null)
        {
            var request = new CreateOrUpdateBookRequest()
            {
                Title = Title,
                Author = Author,
                Description = Description
            };

            var isSuccess = await _bookService.Update(_selectedBook.Id, request);

            if (isSuccess)
            {
                OnRequestClose();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public event EventHandler RequestClose;
    
    protected virtual void OnRequestClose()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}