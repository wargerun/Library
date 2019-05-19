using Library.Data;
using Library.Data.BusinessLogic;   
using System;
using System.Collections.Generic;
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
            InitionalWindow initwindow = new InitionalWindow();
            initwindow.Show();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            RefreshBooks();
        }    

        private void BtnAddbook_Click(object sender, RoutedEventArgs e)
        {
            BooksWindowEditor bookEditor = new BooksWindowEditor();

            if (!bookEditor.ShowDialog().Value)
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

            if (!bookEditor.ShowDialog().Value)
                return;

            RefreshBooks();     
        }

        private void RefreshBooks()
        {
            ThreadPool.QueueUserWorkItem( obj =>
            {
                try
                {
                    IEnumerable<BOOK> books = BooksBl.GetBooks();

                    this.GuiSync(() =>
                    {
                        dgBooks.ItemsSource = null;
                        dgBooks.ItemsSource = books;
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
