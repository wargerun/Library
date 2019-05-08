using System;
using Library.Data.BusinessLogic;
using System.Threading;
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
            BooksWindow booksWindow = new BooksWindow();

            booksWindow.Show();
            Close();
        }

        private void BtnShowWindowViewers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShowWindowIssuedBooks_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
