using System.Windows;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.ViewModels.BookModels;
using MyBooksDesktop.Core.ViewModels.Main;

namespace MyBooksDesktop.Core.Views.Book;

public partial class CreateBookWindow : Window
{
    private readonly INavigationService _navigationService;
    
    public CreateBookWindow(INavigationServiceFactory navigationServiceFactory, CreateBookView createBookView, 
        CreateBookViewModel createBookViewModel, LibraryViewModel libraryViewModel)
    {
        InitializeComponent();
        _navigationService = navigationServiceFactory.Create("CreateBook");
        _navigationService.Initialize(CreateBookFrame);
        CreateBookFrame.Navigate(createBookView);
        
        createBookViewModel.RequestClose += (s, e) => this.Close();
        createBookViewModel.RequestClose += (s, e) => libraryViewModel.InitializeBooks();
    }
    
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        e.Cancel = true; 
        this.Hide();
    }
}