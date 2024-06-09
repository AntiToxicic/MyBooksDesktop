using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.ViewModels.Main;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationService;
    public ICommand LoginCommand { get; }
    
    public MainViewModel(INavigationServiceFactory navigationServiceFactory)
    {
        _navigationService = navigationServiceFactory.Create("Main");
        LoginCommand = new RelayCommand(Login);
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