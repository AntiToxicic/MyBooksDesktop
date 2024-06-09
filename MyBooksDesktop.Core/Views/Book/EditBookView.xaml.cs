using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.BookModels;

namespace MyBooksDesktop.Core.Views.Book;

public partial class EditBookView : UserControl
{
    public EditBookView(EditBookViewModel _editBookViewModel)
    {
        InitializeComponent();
        DataContext = _editBookViewModel;
    }
}