using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace ModifiedCaesarCipher
{
    public partial class MainWindow : Window
    {
        public string text;
        public string timeZone;
        Encryptor encryptor = new Encryptor();
        Decryptor decrypt = new Decryptor();
        InformationAboutProgramm InformationAboutProgramm = new InformationAboutProgramm();
        public MainWindow()
        {
            InitializeComponent();
            addTimeZone();
        }

        private void takeText()
        {
            text=textBox.Text.ToString();
        }
        private void addTimeZone()
        {
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                listOfTimeZones.Items.Add(z.Id);
                listOfTimeZones.SelectedIndex = 0;
            }
        }

        private void shifrButton_Click(object sender, RoutedEventArgs e)
        {
            takeText();
            if (!String.IsNullOrEmpty(textBox.Text))
                ShowResultText(encryptor.startEncryptor(timeZone, text));
            else
                MessageBox.Show("Введите сообщение в тексотове поле");
        }

        private void ShowResultText(string Result)
        {
            result.Text = Result;
        }

        private void unshifrButton_Click(object sender, RoutedEventArgs e)
        {
            takeText();
            if (!String.IsNullOrEmpty(textBox.Text))
                ShowResultText(decrypt.StartDecrypt(text));
            else
                MessageBox.Show("Введите сообщение в тексотове поле");
        }

        private void listOfTimeZones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            timeZone = listOfTimeZones.SelectedItem.ToString();
        }

        private void informationAboutProgramm(object sender, RoutedEventArgs e)
        {
            InformationAboutProgramm.Show();
        }

        private void openFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                textBox.Text = File.ReadAllText(openFileDialog.FileName);

        }

        private void SaveFileButton(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, result.Text);
        }
    }
}
