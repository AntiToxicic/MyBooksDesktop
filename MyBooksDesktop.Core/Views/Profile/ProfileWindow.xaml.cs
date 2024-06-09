using System.Windows;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.ViewModels.Profile;

namespace MyBooksDesktop.Core.Views.Profile;

public partial class ProfileWindow : Window
{
    private readonly INavigationService _navigationService;
    private readonly PreviewProfileViewModel _previewProfileViewModel;
    private readonly EditProfileViewModel _editProfileViewModel;

    public ProfileWindow(INavigationServiceFactory navigationServiceFactory, PreviewProfileView previewProfileView, 
        PreviewProfileViewModel previewProfileViewModel, EditProfileViewModel editProfileViewModel, DeleteProfileViewModel deleteProfileViewModel)
    {
        InitializeComponent();
        _navigationService = navigationServiceFactory.Create("Profile");
        _previewProfileViewModel = previewProfileViewModel;
        _editProfileViewModel = editProfileViewModel;
        _navigationService.Initialize(ProfielFrame);
        ProfielFrame.Navigate(previewProfileView);
        
        deleteProfileViewModel.RequestClose += (s, e) => this.Close();
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        e.Cancel = true; 
        this.Hide();
    }

    public void Initializate()
    {
        _editProfileViewModel.InitializeAsync();
        _previewProfileViewModel.InitializeAsync();
    }
}