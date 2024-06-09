using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Main;

namespace MyBooksDesktop.Core.Views.Main;

public partial class LoginView : UserControl
{
    public LoginView(LoginViewModel loginViewModel, LibraryViewModel libraryViewModel)
    {
        InitializeComponent();
        DataContext = loginViewModel;
        
        loginViewModel.RequestClose += (s, e) => libraryViewModel.InitializeBooks();
    }
    
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as LoginViewModel; 
        if (viewModel != null)
        {
            viewModel.Password = passwordBox.Password;
        }
    }

}