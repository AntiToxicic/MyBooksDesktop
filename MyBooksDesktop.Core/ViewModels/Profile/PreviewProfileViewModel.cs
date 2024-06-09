using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Profile;

public class PreviewProfileViewModel : INotifyPropertyChanged
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;

    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? SurName { get; set; }

    public ICommand ToEditProfileCommand { get; }
    public ICommand ToEditPasswordCommand { get; }
    public ICommand ToDeleteProfileCommand { get; }

    public PreviewProfileViewModel(IUserService userService, INavigationServiceFactory navigationServiceFactory)
    {
        _userService = userService;
        _navigationService = navigationServiceFactory.Create("Profile");
        ToEditProfileCommand = new RelayCommand(ToEditProfile);
        ToEditPasswordCommand = new RelayCommand(ToEditUserPassword);
        ToDeleteProfileCommand = new RelayCommand(ToDeleteProfile);
    }

    public async void InitializeAsync()
    {
        var user = await _userService.Get(UserIdToken.Id);
        if (user is not null)
        {
            Username = user.Username;
            Name = user.Name;
            SurName = user.SurName;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(SurName));
        }
    }

    private void ToDeleteProfile()
    {
        _navigationService.NavigateTo("DeleteProfile");
    }
    
    private void ToEditProfile()
    {
        _navigationService.NavigateTo("EditProfile");
    }
    
    private void ToEditUserPassword()
    {
        _navigationService.NavigateTo("EditPasswordProfile");
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}