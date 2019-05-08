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

            booksWindow.busyIndicator.IsBusy = true;
            ThreadPool.QueueUserWorkItem( obj =>
            {
                try
                {

                    booksWindow.Books = BooksBl.GetBooks();//TODO Need Async

                    this.GuiSync(() => 
                    {
                        booksWindow.Show();
                        Close();
                    });
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
                finally
                {
                    this.GuiSync(() => booksWindow.busyIndicator.IsBusy = false);
                }
            });
        }

        private void BtnShowWindowViewers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShowWindowIssuedBooks_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
