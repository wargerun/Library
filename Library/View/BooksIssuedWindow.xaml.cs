using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.Data;
using Library.Data.BusinessLogic;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BooksIssuedWindow.xaml
    /// </summary>
    public partial class BooksIssuedWindow : Window
    {
        public BooksIssuedWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e) => new InitionalWindow().Show();

        private void Window_ContentRendered(object sender, EventArgs e) => RefreshBooksIssued();
          
        private void BtnAddBookIssued_OnClick(object sender, RoutedEventArgs e)
        {
            BooksIssuedWindowEditor editor = new BooksIssuedWindowEditor();
            editor.ShowDialog();

            if (editor.Manager.IsOk)
                RefreshBooksIssued();
        }

        private void BtnEditBookIssued_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem == null)
                return;

            BooksIssuedWindowEditor editor = new BooksIssuedWindowEditor
            {
                SelectedBooksIssued = ((BOOKS_ISSUED)dgBooks.SelectedItems[0])
            };

            editor.ShowDialog();
            if (!editor.Manager.IsOk)
                return;

            RefreshBooksIssued();
        }   

        private void RefreshBooksIssued()
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    this.GuiSync(() =>
                    {
                        dgBooks.ItemsSource = null;
                        dgBooks.ItemsSource = BooksIssuedBl.GetBooksIssueds();
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
