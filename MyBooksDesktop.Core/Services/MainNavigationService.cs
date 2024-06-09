using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Views;
using MyBooksDesktop.Core.Views.Main;

namespace MyBooksDesktop.Core.Services;

public class MainNavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private Frame _frame;

    public MainNavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Initialize(Frame frame)
    {
        _frame = frame;
    }

    public void NavigateTo(string pageKey)
    {
        switch (pageKey)
        {
            case "Login":
                _frame.Navigate(_serviceProvider.GetRequiredService<LoginView>());
                break;
            case "Register":
                _frame.Navigate(_serviceProvider.GetRequiredService<RegisterView>());
                break;
            case "Library":
                _frame.Navigate(_serviceProvider.GetRequiredService<LibraryView>());
                break;
        }
    }
}

