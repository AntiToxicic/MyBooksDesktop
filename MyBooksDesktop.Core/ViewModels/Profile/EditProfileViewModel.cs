using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Profile;

public class EditProfileViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;

    private string? _name;
    private string? _surName;
    private string _username;
    private string _password;

    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string? SurName
    {
        get => _surName;
        set
        {
            _surName = value;
            OnPropertyChanged(nameof(SurName));
        }
    }

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


    public ICommand ChangeProfileCommand { get; }
    public ICommand BackToProfileCommand { get; }

    public EditProfileViewModel(INavigationServiceFactory navigationServiceFactory, IUserService userService)
    {
        _navigationService = navigationServiceFactory.Create("Profile");
        _userService = userService;
        ChangeProfileCommand = new RelayCommand(ChangeProfile);
        BackToProfileCommand = new RelayCommand(BackToProfile);
    }

    private async void ChangeProfile()
    {
        var loginRequest = new LoginRequest { Username = Username, Password = Password };
        var isPasswordCorrect = await _userService.Login(UserIdToken.Id, loginRequest);

        if (isPasswordCorrect)
        {
            var updateUserRequest = new UpdateUserRequest()
            {
                Username = Username,
                Password = Password,
                Name = Name,
                SurName = SurName
            };

            var isSuccess = await _userService.UpdateUser(UserIdToken.Id, updateUserRequest);
            
            if (isSuccess)
            {
                InitializeAsync();
                _navigationService.NavigateTo("PreviewProfile");
            }
        }
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

    private void BackToProfile()
    {
        _navigationService.NavigateTo("PreviewProfile");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}