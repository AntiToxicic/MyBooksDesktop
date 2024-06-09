using System.Windows;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.ViewModels.Main;
using MyBooksDesktop.Core.Views.Book;
using MyBooksDesktop.Core.Views.Profile;

namespace MyBooksDesktop.Core.Views.Main;

public partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;
    private readonly ProfileWindow _profileWindow;
    private readonly CreateBookWindow _createBookWindow;
    
    public MainWindow(LoginView loginView,  MainViewModel mainViewModel, INavigationServiceFactory navigationServiceFactory, 
        ProfileWindow profileWindow, CreateBookWindow createBookWindow)
    {
        InitializeComponent();
        _navigationService = navigationServiceFactory.Create("Main");
        _navigationService.Initialize(MainFrame);
        MainFrame.Navigate(loginView);
        _profileWindow = profileWindow;
        _createBookWindow = createBookWindow;
        DataContext = mainViewModel;
    }

    private void HelpClick(object sender, RoutedEventArgs e)
    {
        string message = "Программа: MyBooks\nАвтор: Трухин Александр\n\nДанный продукт является тестовым заданием от компании Гармония Здоровья";
        MessageBox.Show(message, "О программе", MessageBoxButton.OK, MessageBoxImage.None);
    }
    
    private void ExitClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    protected override void OnClosed(EventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void OpenProfileClick(object sender, RoutedEventArgs e)
    {
        var profileWindow = _profileWindow;
        _profileWindow.Initializate();
        profileWindow.Show();
    }
    
    private void OpenCreateBookClick(object sender, RoutedEventArgs e)
    {
        _createBookWindow.Show();
    }

}