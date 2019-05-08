using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
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
using Library.Data.Context;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BooksWindowEditor.xaml
    /// </summary>
    public partial class BooksWindowEditor : Window
    {
        public BooksWindowEditor()
        {
            InitializeComponent();
        }
        
        public BOOKS SelectedBook { private get; set; }

        private void BtnAddedBook_OnClick(object sender, RoutedEventArgs e)
        {
            BOOKS book = GetWindowFields();

            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    BooksBl.AddNewCard(book);

                    this.GuiSync(() =>
                    {
                        Close();
                    });
                }
                catch (DbEntityValidationException validationError)
                {
                    string errorsLine = ValidationHelpers.GetValidationErrors(validationError);

                    this.GuiSync(() => MessageBox.Show(errorsLine, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
        }

        

        private void BtnChangeBook_OnClick(object sender, RoutedEventArgs e)
        {
            BOOKS book = GetWindowFields();

            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    BooksBl.UpdateBook(book);

                    this.GuiSync(() =>
                    {
                        DialogResult = true;

                        Close();
                    });
                }
                catch (DbEntityValidationException validationError)
                {
                    string errorsLine = ValidationHelpers.GetValidationErrors(validationError);

                    this.GuiSync(() => MessageBox.Show(errorsLine, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
        }

        private void BtnRemoveBook_OnClick(object sender, RoutedEventArgs e)
        {

            throw new NotImplementedException();
        }
        
        private void BooksWindowEditor_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (SelectedBook == null)
            {
                btnAddedBook.Visibility = Visibility.Visible;
                return;
            }

            btnChangeBook.Visibility = Visibility.Visible;
            btnRemoveBook.Visibility = Visibility.Visible;
            SetWindowField();
        }

        private BOOKS GetWindowFields()
        {
            BOOKS book = new BOOKS
            {
                ID = SelectedBook.ID,
                ISBN = txtIsbn.Text,
                NAME = txtName.Text,
                PRICE = string.IsNullOrWhiteSpace(txtPrice.Text) ? 0 : decimal.Parse(txtPrice.Text),
                AUTHOR = txtAuthor.Text,
                PUBLISHING = txtPublisher.Text,
                COUNT = string.IsNullOrWhiteSpace(txtCount.Text) ? 0 : int.Parse(txtCount.Text),
                STATUS = txtStatus.Text,
                DESCRIPTION = txtDescription.Text
            };

            return book;
        }

        private void SetWindowField()
        {
            txtIsbn.Text = SelectedBook.ISBN;
            txtName.Text = SelectedBook.NAME;
            txtPrice.Text = SelectedBook.PRICE.ToString("N");
            txtAuthor.Text = SelectedBook.AUTHOR;
            txtPublisher.Text = SelectedBook.PUBLISHING;
            txtCount.Text = SelectedBook.COUNT.ToString();
            txtStatus.Text = SelectedBook.STATUS;
            txtDescription.Text = SelectedBook.DESCRIPTION;
        }

        //TODO Сделать обновление после закрытие формы и дописать удаление записи
        private void BooksWindowEditor_OnClosed(object sender, EventArgs e)
        {
            BooksWindow booksWindow = new BooksWindow();

            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    booksWindow.Books = BooksBl.GetBooks();//TODO Need Async
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
        }
    }
}
