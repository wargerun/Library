using Library.Data;
using Library.Data.BusinessLogic;  
using System;
using System.Data.Entity.Validation;
using System.Threading;
using System.Windows;
using NLog;

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

        private static Logger _logger = LogManager.GetCurrentClassLogger();  
        public BOOK SelectedBook { private get; set; }

        private void BtnAddedBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _logger.Info("Getting started: BtnAddedBook_OnClick");

                BOOK book = GetWindowFields();

                PrepareThisAction(() => BooksBl.AddNewCard(book));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 

        private void BtnChangeBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _logger.Info("Getting started: BtnChangeBook_OnClick");
                BOOK book = GetWindowFields();

                PrepareThisAction(() => BooksBl.UpdateBook(book));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }    

        private void BtnRemoveBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _logger.Info("Getting started: BtnRemoveBook_OnClick");
                BOOK book = GetWindowFields();
                   
                PrepareThisAction(() => BooksBl.BooksRemove(new[] { book.ID }));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrepareThisAction(Action bookAction)
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    _logger.Info("Getting started pre proccess database");
                    bookAction();

                    this.GuiSync(() =>
                    {
                        DialogResult = true;

                        Close();
                    });

                    _logger.Info("End-to-end pre proccess database: seccess");  
                }
                catch (DbEntityValidationException validationError)
                {
                    string errorsLine = ValidationHelpers.GetValidationErrors(validationError);

                    this.GuiSync(() => MessageBox.Show(errorsLine, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
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

        private BOOK GetWindowFields()
        {
            BOOK book = new BOOK
            {
                ID = SelectedBook?.ID ?? 0,
                ISBN = txtIsbn.Text,
                NAME = txtName.Text,
                PRICE = string.IsNullOrWhiteSpace(txtPrice.Text) ? 0 : decimal.Parse(txtPrice.Text),
                AUTHOR = txtAuthor.Text,
                PUBLISHING = txtPublisher.Text,
                COUNT = string.IsNullOrWhiteSpace(txtCount.Text) ? 0 : int.Parse(txtCount.Text),
                STATUS = txtStatus.Text,
                DESCRIPTION = txtDescription.Text
            };

            if (book.COUNT < 0 )
                throw new Exception($"Кол-во не может быть отрицательное!");

            if (book.PRICE < 0)
                throw new Exception($"Цена не может быть отрицательное!");  

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
    }
}
