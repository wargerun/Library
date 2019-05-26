using System.Windows;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for InitionalWindow.xaml
    /// </summary>
    public partial class InitionalWindow : Window
    {
        public InitionalWindow()
        {
            InitializeComponent();
        }

        private void BtnShowWindowBooks_Click(object sender, RoutedEventArgs e)
        {
            new BooksWindow().Show();

            Close();
        }

        private void BtnShowWindowViewers_Click(object sender, RoutedEventArgs e)
        {
            new ViewersWindow().Show();

            Close();
        }

        private void BtnShowWindowIssuedBooks_Click(object sender, RoutedEventArgs e)
        {
            new BooksIssuedWindow().Show();

            Close();
        }
    }
}
