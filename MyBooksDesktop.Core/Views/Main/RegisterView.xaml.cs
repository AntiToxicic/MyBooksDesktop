using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Main;

namespace MyBooksDesktop.Core.Views.Main;

public partial class RegisterView : UserControl
{
    public RegisterView(RegisterViewModel registerViewModel)
    {
        InitializeComponent();
        DataContext = registerViewModel;
    }
    
    private void Password_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as RegisterViewModel; 
        if (viewModel != null)
        {
            viewModel.Password = passwordBox.Password;
        }
    }
    
    private void PasswordRepeat_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as RegisterViewModel; 
        if (viewModel != null)
        {
            viewModel.PasswordRepeat = passwordBox.Password;
        }
    }
}