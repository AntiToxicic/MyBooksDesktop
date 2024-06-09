using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBooksDesktop.Core.Factories;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Services;
using MyBooksDesktop.Core.ViewModels;
using MyBooksDesktop.Core.ViewModels.BookModels;
using MyBooksDesktop.Core.ViewModels.Main;
using MyBooksDesktop.Core.ViewModels.Profile;
using MyBooksDesktop.Core.Views;
using MyBooksDesktop.Core.Views.Book;
using MyBooksDesktop.Core.Views.Main;
using MyBooksDesktop.Core.Views.Profile;
using MyBooksDesktop.Infrastructure.Services;

namespace MyBooksDesktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
            })
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<ProfileWindow>();
        services.AddSingleton<PreviewProfileView>();
        services.AddSingleton<PreviewProfileViewModel>();
        services.AddSingleton<EditPasswordProfileView>();
        services.AddSingleton<EditPasswordProfileViewModel>();
        services.AddSingleton<DeleteProfileView>();
        services.AddSingleton<DeleteProfileViewModel>();
        services.AddSingleton<LoginView>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<RegisterView>();
        services.AddSingleton<RegisterViewModel>();
        services.AddSingleton<LibraryView>();
        services.AddSingleton<LibraryViewModel>();
        services.AddSingleton<EditProfileView>();
        services.AddSingleton<EditProfileViewModel>();
        services.AddSingleton<CreateBookViewModel>();
        services.AddSingleton<CreateBookView>();
        services.AddSingleton<CreateBookWindow>();
        services.AddSingleton<EditBookViewModel>();
        services.AddSingleton<EditBookView>();
        services.AddSingleton<EditBookWindow>();
        services.AddSingleton<MainNavigationService>();
        services.AddSingleton<ProfileNavigationService>();
        services.AddSingleton<CreateBookNavigationService>();
        services.AddSingleton<EditBookNavigationService>();
        services.AddSingleton<INavigationServiceFactory, NavigationServiceFactory>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IBookService, BookService>();
    }

    public void OnStartup(object sender, StartupEventArgs e)
    {
        _host.Start();
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }


    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
        base.OnExit(e);
    }
}