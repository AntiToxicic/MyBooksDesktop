using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Main;

public class LibraryViewModel : INotifyPropertyChanged
{
    private readonly IBookService _bookService;

    private Book _selectedBook;

    public ObservableCollection<Book> Books { get; set; }

    public Book SelectedBook
    {
        get
        {
            return _selectedBook;
        }
        set
        {
            _selectedBook = value;
            OnPropertyChanged("SelectedBook");
        }
    }

    public ICommand DeleteBookCommand { get; }
    public ICommand InitializeBooksCommand { get; }

    public LibraryViewModel(IBookService bookService)
    {
        _bookService = bookService;
        DeleteBookCommand = new RelayCommand(DeleteBook);
        InitializeBooksCommand = new RelayCommand(InitializeBooks);
        
        InitializeBooks();
    }

    public async void InitializeBooks()
    {
        var books = await _bookService.GetAllBooks(UserIdToken.Id);
        Books = new ObservableCollection<Book>(books);
        OnPropertyChanged(nameof(Books));
        
        Console.WriteLine("asdfsdfsdf");
    }

    public async void DeleteBook()
    {
        Console.WriteLine("asdfsdfsdf");
        await _bookService.Delete(_selectedBook.Id);
        
        InitializeBooks();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}