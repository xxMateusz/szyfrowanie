using System;
using System.Text;
using System.Windows;

namespace CezarCipherWPF
{
    public partial class MainWindow : Window
    {
        private string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźżABCDEFGHIJKLMNOPQRSTUVWXYZXQV";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            string inputText = txtInput.Text;
            int offset;

            if (int.TryParse(txtOffset.Text, out offset))
            {
                if (offset >= 1 && offset <= alphabet.Length)
                {
                    string encryptedText = EncryptCezar(inputText, offset);
                    txtEncrypted.Text = encryptedText;
                }
                else
                {
                    MessageBox.Show("Przesunięcie musi być liczbą od 1 do " + alphabet.Length + ".", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Niepoprawna wartość przesunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string EncryptCezar(string input, int offset)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in input)
            {
                int index = alphabet.IndexOf(c);

                if (index != -1)
                {
                    int newIndex = (index + offset) % alphabet.Length;
                    char encryptedChar = alphabet[newIndex];
                    encryptedText.Append(encryptedChar);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString().Replace(" ", string.Empty);
        }
        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            string inputText = txtInputDecrypt.Text;
            int offset;

            if (int.TryParse(txtOffsetDecrypt.Text, out offset))
            {
                if (offset >= 1 && offset <= alphabet.Length)
                {
                    string decryptedText = DecryptCezar(inputText, offset);
                    txtDecrypted.Content = decryptedText;
                }
                else
                {
                    MessageBox.Show("Przesunięcie musi być liczbą od 1 do " + alphabet.Length + ".", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Niepoprawna wartość przesunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string DecryptCezar(string input, int offset)
        {
            StringBuilder decryptedText = new StringBuilder();

            foreach (char c in input)
            {
                int index = alphabet.IndexOf(c);

                if (index != -1)
                {
                    int newIndex = (index - offset + alphabet.Length) % alphabet.Length;
                    char decryptedChar = alphabet[newIndex];
                    decryptedText.Append(decryptedChar);
                }
                else
                {
                    decryptedText.Append(c);
                }
            }

            return decryptedText.ToString();
        }

    }
}
