using System.ComponentModel;
using System.Windows;

namespace ModifiedCaesarCipher
{
    /// <summary>
    /// Логика взаимодействия для InformationAboutProgramm.xaml
    /// </summary>
    public partial class InformationAboutProgramm : Window
    {
        public InformationAboutProgramm()
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
