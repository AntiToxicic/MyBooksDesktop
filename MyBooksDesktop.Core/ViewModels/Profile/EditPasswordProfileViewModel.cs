using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Profile;

public class EditPasswordProfileViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;

    private string _oldPassword;
    private string _newPassword;
    private string _newRepeatPassword;

    public string OldPassword
    {
        get => _oldPassword;
        set
        {
            _oldPassword = value;
            OnPropertyChanged(nameof(OldPassword));
        }
    }

    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChanged(nameof(NewPassword));
        }
    }

    public string NewRepeatPassword
    {
        get => _newRepeatPassword;
        set
        {
            _newRepeatPassword = value;
            OnPropertyChanged(nameof(NewRepeatPassword));
        }
    }

    public ICommand ChangePasswordCommand { get; }
    public ICommand BackToProfileCommand { get; }

    public EditPasswordProfileViewModel(INavigationServiceFactory navigationServiceFactory, IUserService userService)
    {
        _navigationService = navigationServiceFactory.Create("Profile");
        _userService = userService;
        ChangePasswordCommand = new RelayCommand(ChangePassword);
        BackToProfileCommand = new RelayCommand(BackToProfile);
    }

    private async void ChangePassword()
    {
        if (NewPassword != NewRepeatPassword) return;

        var passwordRequest = new UpdateUserPasswordRequest()
        {
            OldPassword = OldPassword,
            NewPassword = NewPassword
        };

        var isSuccess = await _userService.UpdatePassword(UserIdToken.Id, passwordRequest);

        if (isSuccess)
        {
            _navigationService.NavigateTo("PreviewProfile");
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