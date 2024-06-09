using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Profile;

namespace MyBooksDesktop.Core.Views.Profile;

public partial class EditPasswordProfileView : UserControl
{
    public EditPasswordProfileView(EditPasswordProfileViewModel editPasswordProfileViewModel)
    {
        InitializeComponent();
        DataContext = editPasswordProfileViewModel;
    }
    
    private void OldPassword_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as EditPasswordProfileViewModel; 
        if (viewModel != null)
        {
            viewModel.OldPassword = passwordBox.Password;
        }
    }
    
    private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as EditPasswordProfileViewModel; 
        if (viewModel != null)
        {
            viewModel.NewPassword = passwordBox.Password;
        }
    }
    
    private void NewRepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as EditPasswordProfileViewModel; 
        if (viewModel != null)
        {
            viewModel.NewRepeatPassword = passwordBox.Password;
        }
    }
}