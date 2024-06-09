namespace MyBooksDesktop.Core.Interfaces;

public interface INavigationServiceFactory
{
    INavigationService Create(string serviceType);
}