using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Views;
using MyBooksDesktop.Core.Views.Profile;

namespace MyBooksDesktop.Core.Services;

public class ProfileNavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private Frame _frame;

    public ProfileNavigationService(IServiceProvider serviceProvider)
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
            case "EditPasswordProfile":
                _frame.Navigate(_serviceProvider.GetRequiredService<EditPasswordProfileView>());
                break;
            case "PreviewProfile":
                _frame.Navigate(_serviceProvider.GetRequiredService<PreviewProfileView>());
                break;
            case "EditProfile":
                _frame.Navigate(_serviceProvider.GetRequiredService<EditProfileView>());
                break;
            case "DeleteProfile":
                _frame.Navigate(_serviceProvider.GetRequiredService<DeleteProfileView>());
                break;
        }
    }
}

