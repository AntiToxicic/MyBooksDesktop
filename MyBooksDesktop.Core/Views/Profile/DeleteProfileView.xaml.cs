using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Profile;

namespace MyBooksDesktop.Core.Views.Profile;

public partial class DeleteProfileView : UserControl
{
    public DeleteProfileView(DeleteProfileViewModel deleteProfileViewModel)
    {
        InitializeComponent();
        DataContext = deleteProfileViewModel;
    }
    
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = sender as PasswordBox;
        var viewModel = DataContext as DeleteProfileViewModel; 
        if (viewModel != null)
        {
            viewModel.Password = passwordBox.Password;
        }
    }

}