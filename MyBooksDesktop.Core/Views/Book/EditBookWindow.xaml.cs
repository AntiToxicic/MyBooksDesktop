using System.Windows;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.ViewModels.BookModels;
using MyBooksDesktop.Core.ViewModels.Main;
using MyBooksDesktop.Core.Views.Main;

namespace MyBooksDesktop.Core.Views.Book;

public partial class EditBookWindow : Window
{
    private readonly INavigationService _navigationService;
    private readonly EditBookViewModel _editBookViewModel;
    private readonly LibraryViewModel _libraryViewModel;
    
    public EditBookWindow(INavigationServiceFactory navigationServiceFactory, EditBookViewModel editBookViewModel,
        LibraryViewModel libraryViewModel, EditBookView editBookView)
    {
        InitializeComponent();
        _navigationService = navigationServiceFactory.Create("EditBook");
        _navigationService.Initialize(EditBookFrame);
        EditBookFrame.Navigate(editBookView);
        _editBookViewModel = editBookViewModel;
        _libraryViewModel = libraryViewModel;
        
        editBookViewModel.RequestClose += (s, e) => this.Close();
        editBookViewModel.RequestClose += (s, e) => libraryViewModel.InitializeBooks();
    }
    
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        e.Cancel = true; 
        this.Hide();
    }
    
    public void Initializate()
    {
        _editBookViewModel.Initialize(_libraryViewModel.SelectedBook);
    }
}