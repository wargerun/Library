using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = System.Drawing.Image;

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

        public IEnumerable<BOOKS> Books { private get; set; }

        private void Window_Closed(object sender, EventArgs e)
        {
            InitionalWindow initwindow = new InitionalWindow();
            initwindow.Show();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            dgBooks.ItemsSource = Books;
        }

        private void BtnAddbook_Click(object sender, RoutedEventArgs e)
        {
            BooksWindowEditor bookEditor = new BooksWindowEditor();
            bookEditor.ShowDialog();
        }

        private void BtnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem == null)
                return;

            BooksWindowEditor bookEditor = new BooksWindowEditor
            {
                SelectedBook =((BOOKS)dgBooks.SelectedItems[0]) 
            };

            if (!bookEditor.ShowDialog().Value)
                return;

            //TODO Сделать обновление после закрытие формы и дописать удаление записи
            dgBooks.ItemsSource = null;
            dgBooks.ItemsSource = Books;       
        }

        private void BtnRemoveBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
