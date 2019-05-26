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
using Library.Helpers;
using NLog;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BooksIssuedWindowEditor.xaml
    /// </summary>
    public partial class BooksIssuedWindowEditor : Window
    {
        public BooksIssuedWindowEditor()
        {
            InitializeComponent();
        }  

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public BOOKS_ISSUED SelectedBooksIssued { private get; set; }

        private IEnumerable<VIEWER> Viewers { get; set; }
        private IEnumerable<BOOK> Books { get; set; }

        public readonly DbManager<BOOKS_ISSUED> Manager = new DbManager<BOOKS_ISSUED>(null, null);

        //TODO Подумать что можно сделать чтобы вытащить   VIEWER and BOOK из таблицы BOOKS_ISSUED
        private async void BooksIssuedWindowEditor_OnLoaded(object sender, RoutedEventArgs e)
        {
            cbVeiwer.ItemsSource = Viewers = await Task.Run(() => ViewerBl.GetViewers());
            Books = await Task.Run(() => BooksBl.GetBooks());
               
            if (SelectedBooksIssued == null)
            {
                btnAddedBooksIssued.Visibility = Visibility.Visible;
                return;
            }

            btnChangeBookIssued.Visibility = Visibility.Visible;
            btnRemoveBookIssued.Visibility = Visibility.Visible;
            SetWindowField();
        }

        private void BtnAddedBooksIssued_OnClick(object sender, RoutedEventArgs e)
        {           
            throw new NotImplementedException();
        }

        private void BtnChangeBookIssued_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRemoveBookIssued_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private BOOKS_ISSUED GetWindowFields()
        {
            //if (!decimal.TryParse(txtPrice.Text, out decimal price) || !int.TryParse(txtCount.Text, out int count))
            //    throw new Exception("Цена или кол-во не верны");

            //BOOK book = new BOOK
            //{
            //    ID = SelectedBook?.ID ?? 0,
            //    ISBN = txtIsbn.Text,
            //    NAME = txtName.Text,
            //    PRICE = price,
            //    AUTHOR = txtAuthor.Text,
            //    PUBLISHING = txtPublisher.Text,
            //    COUNT = count,
            //    STATUS = txtStatus.Text,
            //    DESCRIPTION = txtDescription.Text
            //};

            return new BOOKS_ISSUED();
        }

        private void SetWindowField()
        {
            dpIssueDate.SelectedDate = SelectedBooksIssued.ISSUED_DATE;
            dpReturnDate.SelectedDate = SelectedBooksIssued.RETURN_DATE;
            //TODO Подумать что можно сделать чтобы вытащить   VIEWER and BOOK из таблицы BOOKS_ISSUED
            //cbVeiwer.SelectedValue = Viewers.Single(v => v.ID == SelectedBooksIssued.VIEWERS.ID);

        }
    }
}
