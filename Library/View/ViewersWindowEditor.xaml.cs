using Library.Data;
using NLog;        
using System;
using System.Windows;

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

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public VIEWER SelectedViewer { private get; set; }

        private void ViewersWindowEditor_OnLoaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
