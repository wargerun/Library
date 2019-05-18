using Library.Data.BusinessLogic;   
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Library.Data;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for ViewersWindow.xaml
    /// </summary>
    public partial class ViewersWindow : Window
    {
        public ViewersWindow()
        {
            InitializeComponent();
        }

        private void ViewersWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            RefreshViewers();
        }

        private void RefreshViewers()
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    IEnumerable<VIEWER> viewers = ViewerBl.GetViewers();
                    this.GuiSync(() =>
                    {
                        dgViewers.ItemsSource = null;
                        dgViewers.ItemsSource = viewers;
                    });
                }
                catch (Exception ex)
                {
                    this.GuiSync(() => MessageBox.Show(ex.Message, "Не удалось обновить таблицу!", MessageBoxButton.OK, MessageBoxImage.Error));
                }
            });
        }

        private void ViewersWindow_OnClosed(object sender, EventArgs e)
        {
            new InitionalWindow().Show();
        }

        private void BtnAddViewer_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnEditViewer_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgViewers.SelectedItem == null)
                return;

            ViewersWindowEditor viewerEditor = new ViewersWindowEditor
            {
                SelectedViewer = ((VIEWER)dgViewers.SelectedItems[0])
            };

            if (!viewerEditor.ShowDialog().Value)
                return;

            RefreshViewers();    
        }                  
    }
}
