using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace YourProjectNamespace
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Page currentPage;

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // Окно с авторизацией при запуске 
            Login();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Login()
        {
            // Логика авторизации

            if (authorized)
            {
                CurrentPage = new AuthenticatedPage(); // Переход на авторизированную страницу
            }
            else
            {
                CurrentPage = new LoginPage(); // Переход на страницу с формой ввода 
            }
        }
    }

    public class AuthenticatedPage : Page
    {
        public AuthenticatedPage(object grid)
        {
            Content = new Grid();
            TextBlock welcomeTextBlock = new TextBlock();
            welcomeTextBlock.Text = "Добро пожаловать!";
            grid.Children.Add(welcomeTextBlock);

            Content = grid;
        }
    }

    public class LoginPage : Page
    {
        public LoginPage(object grid)
        {
            Content = new Grid();
            TextBox codeWordTextBox = new TextBox();
            Button loginButton = new Button();
            loginButton.Content = "Войти";
            grid.Children.Add(codeWordTextBox);
            grid.Children.Add(loginButton);

            Content = grid;
        }
    }
}
