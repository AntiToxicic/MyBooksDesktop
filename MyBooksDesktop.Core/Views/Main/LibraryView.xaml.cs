using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Main;
using MyBooksDesktop.Core.Views.Book;

namespace MyBooksDesktop.Core.Views.Main;

public partial class LibraryView : UserControl
{
    private readonly EditBookWindow _editBookWindow;
    
    public LibraryView(LibraryViewModel libraryViewModel, EditBookWindow editBookWindow)
    {
        InitializeComponent();
        _editBookWindow = editBookWindow;
        DataContext = libraryViewModel;
    }

    private void OpenEditBookClick(object sender, RoutedEventArgs e)
    {
        var editBookWindow = _editBookWindow;
        _editBookWindow.Initializate();
        editBookWindow.Show();
    }
}