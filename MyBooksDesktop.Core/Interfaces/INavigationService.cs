using System.Windows.Controls;

namespace MyBooksDesktop.Core.Interfaces;

public interface INavigationService
{
    void NavigateTo(string pageKey);
    public void Initialize(Frame frame);

}
