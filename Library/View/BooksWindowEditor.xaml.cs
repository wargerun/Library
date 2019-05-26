using Library.Data;
using Library.Data.BusinessLogic;  
using System;
using System.Threading;
using System.Windows;
using Library.Helpers;
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

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();  
        public BOOK SelectedBook { private get; set; }

        public readonly DbManager<BOOK> Manager = new DbManager<BOOK>(new ManagerBook(), null);     

        private void BtnAddedBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnAddedBook_OnClick");

                BOOK book = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Manager.Entity = book;

                    Manager.AddNewRow();

                    if (Manager.IsOk)
                        this.GuiSync(Close);
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 

        private void BtnChangeBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnChangeBook_OnClick");
                BOOK book = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Manager.Entity = book;
                    Manager.UpdateRow();

                    if (Manager.IsOk)
                        this.GuiSync(Close);
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }    

        private void BtnRemoveBook_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnRemoveBook_OnClick");
                BOOK book = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Manager.Entity = book;
                    Manager.RemoveRow();

                    if (Manager.IsOk)
                        this.GuiSync(Close);
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || !int.TryParse(txtCount.Text, out int count))
                throw new Exception("Цена или кол-во не верны");

            BOOK book = new BOOK
            {
                ID = SelectedBook?.ID ?? 0,
                ISBN = txtIsbn.Text,
                NAME = txtName.Text,
                PRICE = price,
                AUTHOR = txtAuthor.Text,
                PUBLISHING = txtPublisher.Text,
                COUNT = count,
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
    }
}
