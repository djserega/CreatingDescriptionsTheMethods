using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreatingDescriptionsTheMethods
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GlobalHotKeyManager _hotKeyManager = new GlobalHotKeyManager();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            ProcessTextInClipboardEvents.ProcessTextInClipboardEvent += 
                () =>
                {
                    ProcessTextWithClipboard();
                    SetDescriptionToClipboard();
                };
        }

        public Models.DataMethod DataMethod { get; set; } = new Models.DataMethod();

        private void ButtonGetTextInClipboar_Click(object sender, RoutedEventArgs e)
        {
            ProcessTextWithClipboard();

            BindingOperations.GetBindingExpression(TextBoxDescription, TextBox.TextProperty).UpdateTarget();
            BindingOperations.GetBindingExpression(TextBlockError, TextBlock.TextProperty).UpdateTarget();
        }

        private void ButtonTextToClipboard_Click(object sender, RoutedEventArgs e)
        {
            SetDescriptionToClipboard();
        }

        private void ProcessTextWithClipboard()
        {
            if (Clipboard.ContainsText())
                DataMethod.StringMethod = Clipboard.GetText();
        }

        private void SetDescriptionToClipboard()
        {
            Clipboard.SetText(DataMethod.Description);
        }
    }
}
