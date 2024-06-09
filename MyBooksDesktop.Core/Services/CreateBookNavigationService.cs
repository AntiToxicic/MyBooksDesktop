using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Views;
using MyBooksDesktop.Core.Views.Book;
using MyBooksDesktop.Core.Views.Main;

namespace MyBooksDesktop.Core.Services;

public class CreateBookNavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private Frame _frame;

    public CreateBookNavigationService(IServiceProvider serviceProvider)
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
            case "EditBook":
                _frame.Navigate(_serviceProvider.GetRequiredService<EditBookView>());
                break;
        }
    }
}

