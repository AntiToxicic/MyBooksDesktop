using System.Windows;
using System.Windows.Controls;
using MyBooksDesktop.Core.ViewModels.Profile;

namespace MyBooksDesktop.Core.Views.Profile;

public partial class PreviewProfileView : UserControl
{
    private readonly PreviewProfileViewModel _previewProfileViewModel;
    
    public PreviewProfileView(PreviewProfileViewModel previewProfileViewModel)
    {
        _previewProfileViewModel = previewProfileViewModel;
        InitializeComponent();
        DataContext = previewProfileViewModel;
    }
    
    private void OnUpdateUser(object sender, RoutedEventArgs e)
    {
        _previewProfileViewModel.InitializeAsync();
    }
}