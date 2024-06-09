using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Main;

public class RegisterViewModel : INotifyPropertyChanged
{
    private INavigationService _navigationService;
    private IUserService _userService;

    private string _username;
    private string _password;
    private string _passwordRepeat;
    private string _name;
    private string _surName;
    
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
    
    public string PasswordRepeat
    {
        get => _passwordRepeat;
        set
        {
            _passwordRepeat = value;
            OnPropertyChanged(nameof(PasswordRepeat));
        }
    }
    
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    public string SurName
    {
        get => _surName;
        set
        {
            _surName = value;
            OnPropertyChanged(nameof(SurName));
        }
    }
    
    public ICommand RegisterCommand { get; }
    public ICommand LoginCommand { get; }
    
    public RegisterViewModel(INavigationServiceFactory navigationServiceFactory, IUserService userService)
    {
        _navigationService = navigationServiceFactory.Create("Main");
        _userService = userService;
        RegisterCommand = new RelayCommand(Register);
        LoginCommand = new RelayCommand(Login);
    }
    
    private async void Register()
    {
        if(Password != PasswordRepeat) return;
        
        var registerRequest = new RegisterRequest()
        {
            Username = Username, 
            Password = Password,
            Name = Name,
            SurName = SurName
        };
        
        var isSuccess = await _userService.Register(UserIdToken.Id, registerRequest);

        if (isSuccess)
        {
            _navigationService.NavigateTo("Login");
        }
    }
    
    private void Login()
    {
        _navigationService.NavigateTo("Login");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}