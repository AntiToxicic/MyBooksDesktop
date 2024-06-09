using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.BookModels;

public class CreateBookViewModel : INotifyPropertyChanged
{
    private readonly IBookService _bookService;
    
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

    public ICommand CreateBookCommand { get; set; }

    public CreateBookViewModel(IBookService bookService)
    {
        _bookService = bookService;
        CreateBookCommand = new RelayCommand(CreateBook);
    }
    
    public async void CreateBook()
    {
        if (Title != null)
        {
            var request = new CreateOrUpdateBookRequest()
            {
                Title = Title,
                Author = Author,
                Description = Description
            };

            var isSuccess = await _bookService.Create(UserIdToken.Id, request);

            if (isSuccess)
            {
                OnRequestClose();
                
                Title = null;
                Author = null;
                Description = null;
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