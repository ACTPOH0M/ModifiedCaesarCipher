using System.ComponentModel;
using System.Windows;

namespace ModifiedCaesarCipher
{
    /// <summary>
    /// Логика взаимодействия для AnalysisWindow.xaml
    /// </summary>
    public partial class AnalysisWindow : Window
    {
        public AnalysisWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }
    }
}
