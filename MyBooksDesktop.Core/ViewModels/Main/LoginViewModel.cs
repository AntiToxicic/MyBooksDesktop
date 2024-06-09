using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Main;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;

    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterCommand { get; }


    public LoginViewModel(INavigationServiceFactory navigationServiceFactory, IUserService userService)
    {
        _navigationService = navigationServiceFactory.Create("Main");
        _userService = userService;
        LoginCommand = new RelayCommand(Login);
        RegisterCommand = new RelayCommand(Register);
    }

    private async void Login()
    {
        var loginRequest = new LoginRequest { Username = Username, Password = Password };
        var isSuccess = await _userService.Login(UserIdToken.Id, loginRequest);

        if (isSuccess)
        {
            _navigationService.NavigateTo("Library");
            OnRequestClose();
        }
    }

    private void Register()
    {
        _navigationService.NavigateTo("Register");
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