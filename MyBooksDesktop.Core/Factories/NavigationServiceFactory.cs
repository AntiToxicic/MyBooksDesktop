using Microsoft.Extensions.DependencyInjection;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Services;

namespace MyBooksDesktop.Core.Factories;

public class NavigationServiceFactory : INavigationServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public INavigationService Create(string serviceType)
    {
        return serviceType switch
        {
            "Main" => _serviceProvider.GetRequiredService<MainNavigationService>(),
            "Profile" => _serviceProvider.GetRequiredService<ProfileNavigationService>(),
            "CreateBook" => _serviceProvider.GetRequiredService<CreateBookNavigationService>(),
            "EditBook" => _serviceProvider.GetRequiredService<EditBookNavigationService>(),
            _ => throw new ArgumentException("Invalid service type", nameof(serviceType))
        };
    }
}