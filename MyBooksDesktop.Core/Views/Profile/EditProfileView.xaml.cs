using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Profile;

namespace MyBooksDesktop.Core.Views.Profile;

public partial class EditProfileView : UserControl
{
    public EditProfileView(EditProfileViewModel editProfileViewModel)
    {
        InitializeComponent();
        DataContext = editProfileViewModel;
    }
    
    private void Password_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as EditProfileViewModel; 
        if (viewModel != null)
        {
            viewModel.Password = passwordBox.Password;
        }
    }
}