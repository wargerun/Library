using Library.Data;
using Library.Data.BusinessLogic; 
using System;
using System.Threading;
using System.Windows;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        public BooksWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new InitionalWindow().Show();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            RefreshBooks();
        }    

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            BooksWindowEditor bookEditor = new BooksWindowEditor();

            bookEditor.ShowDialog();
            if (!bookEditor.Manager.IsOk)
                return;

            RefreshBooks();
        }

        private void BtnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem == null)
                return;

            BooksWindowEditor bookEditor = new BooksWindowEditor
            {
                SelectedBook =((BOOK)dgBooks.SelectedItems[0]) 
            };

            bookEditor.ShowDialog();
            if (!bookEditor.Manager.IsOk)
                return;

            RefreshBooks();
        }

        private void RefreshBooks()
        {
            ThreadPool.QueueUserWorkItem( obj =>
            {
                try
                {
                    this.GuiSync(() =>
                    {
                        dgBooks.ItemsSource = null;
                        dgBooks.ItemsSource = BooksBl.GetBooks(); 
                    });
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Не удалось обновить таблицу!", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
        }
    }
}
