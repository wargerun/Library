using Library.Data;
using NLog;        
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using Library.Data.BusinessLogic;
using Library.Helpers;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for ViewersWindowEditor.xaml
    /// </summary>
    public partial class ViewersWindowEditor : Window
    {
        public ViewersWindowEditor()
        {
            InitializeComponent();
        }    

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public VIEWER SelectedViewer { private get; set; }

        public readonly DbManager<VIEWER> Manager = new DbManager<VIEWER>(new ManagerViewer(), null);

        private void ViewersWindowEditor_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (SelectedViewer == null)
            {
                btnAddedViewer.Visibility = Visibility.Visible;
                return;
            }

            btnChangeViewer.Visibility = Visibility.Visible;
            btnRemoveViewer.Visibility = Visibility.Visible;
            SetWindowField();
        }

        private void SetWindowField()
        {
            txtName.Text = SelectedViewer.NAME;
            txtSurname.Text = SelectedViewer.SURNAME;
            txtMiddleName.Text = SelectedViewer.MIDDLE_NAME;
            txtAddress.Text = SelectedViewer.ADDRESS;
            txtPhone.Text = SelectedViewer.PHONE;
            txtEmail.Text = SelectedViewer.EMAIL;
        }

        private VIEWER GetWindowFields()
        {
            VIEWER viewer = new VIEWER
            {
                ID = SelectedViewer?.ID ?? 0,
                NAME = txtName.Text,
                SURNAME = txtSurname.Text,
                MIDDLE_NAME = txtMiddleName.Text,
                ADDRESS = txtAddress.Text,
                PHONE = txtPhone.Text,
                EMAIL = txtEmail.Text
            }; 

            if (!string.IsNullOrWhiteSpace(viewer.EMAIL) && !new[] { "@", "." }.All(v => viewer.EMAIL.Contains(v)))
                throw new Exception($"Почта {viewer.SURNAME} введена не верно!");

            return viewer;
        }

        private void BtnAddedViewer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnAddedViewer_OnClick");
                VIEWER viewer = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj => 
                {
                    Manager.Entity = viewer;
                    
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

        private void BtnChangeViewer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnChangeViewer_OnClick");
                VIEWER viewer = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Manager.Entity = viewer;
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

        private void BtnRemoveViewer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Logger.Info("Getting started: BtnRemoveViewer_OnClick");
                VIEWER viewer = GetWindowFields();

                ThreadPool.QueueUserWorkItem(obj =>
                {
                    Manager.Entity = viewer;
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
    }
}
