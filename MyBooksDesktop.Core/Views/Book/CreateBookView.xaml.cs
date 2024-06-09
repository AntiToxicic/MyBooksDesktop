using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.BookModels;

namespace MyBooksDesktop.Core.Views.Book;

public partial class CreateBookView : UserControl
{
    public CreateBookView(CreateBookViewModel createBookViewModel)
    {
        InitializeComponent();
        DataContext = createBookViewModel;
    }
    
    
}