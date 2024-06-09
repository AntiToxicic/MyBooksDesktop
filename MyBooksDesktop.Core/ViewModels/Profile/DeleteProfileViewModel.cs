using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Profile;

public class DeleteProfileViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationServiceMain;
    private readonly INavigationService _navigationServiceProfile;
    private readonly IUserService _userService;
    
    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public ICommand DeleteProfileCommand { get; }
    public ICommand BackToProfileCommand { get; }


    public DeleteProfileViewModel(INavigationServiceFactory navigationServiceFactory, IUserService userService)
    {
        _navigationServiceMain = navigationServiceFactory.Create("Main");
        _navigationServiceProfile = navigationServiceFactory.Create("Profile");
        _userService = userService;
        DeleteProfileCommand = new RelayCommand(Delete);
        BackToProfileCommand = new RelayCommand(ToProfile);
    }

    private async void Delete()
    {
        var user = await _userService.Get(UserIdToken.Id);
        if (user is null) return;
        
        if(user.Password != Password) return;
        
        var isSuccess = await _userService.Delete(UserIdToken.Id);

        if (isSuccess)
        {
            _navigationServiceMain.NavigateTo("Login");
            OnRequestClose();
        }
        
    }

    private void ToProfile()
    {
        _navigationServiceProfile.NavigateTo("PreviewProfile");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public event EventHandler RequestClose;
    
    protected virtual void OnRequestClose()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
}