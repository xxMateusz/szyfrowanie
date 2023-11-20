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
using System.Windows.Shapes;

namespace szyfrowanie
{
    /// <summary>
    /// Logika interakcji dla klasy polubiusz.xaml
    /// </summary>
    public partial class polubiusz : Window
    {
        private Dictionary<char, string> polibiuszTable = new Dictionary<char, string>
        {
            {'f', "11"}, {'ę', "12"}, {'o', "13"}, {'q', "14"}, {'ź', "15"}, {'z', "16"}, {'l', "17"},{'ą',"21"},{'j',"22"},{'ń',"23"},{'h',"24"},{'c',"25"},{'n',"26"},{'u',"27"},{'g',"31"},{'b',"32"},{'a',"33"},{'ż',"34"},{'s',"35"},{'v',"36"},{'w',"37"},{'d',"41"},{'e',"42"},{'k',"43"},{'p',"44"},{'t',"45"},{'i',"46"},{'m',"47"},{'ł',"51"},{'ć',"52"},{'r',"53"},{'ó',"54"},{'ś',"55"},{'x',"56"},{'y',"57"}
          
        };
        private Dictionary<string, char> reversePolibiuszTable;
        public polubiusz()
        {
            InitializeComponent();
            reversePolibiuszTable = polibiuszTable.ToDictionary(x => x.Value, x => x.Key);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text.ToLower(); 
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in inputText)
            {
                if (polibiuszTable.ContainsKey(c))
                {
                    encryptedText.Append(polibiuszTable[c]);
                }
                else
                {
                    encryptedText.Append(c); 
                }
            }

            EncryptedTextBox.Text = encryptedText.ToString();
        }
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;

          
            StringBuilder decryptedText = new StringBuilder();

            if (inputText.Length % 2 == 0)
            {
                for (int i = 0; i < inputText.Length; i += 2)
                {
                    string code = inputText.Substring(i, 2);
                    if (reversePolibiuszTable.ContainsKey(code))
                    {
                        decryptedText.Append(reversePolibiuszTable[code]);
                    }
                    else
                    {
                        decryptedText.Append(code); 
                    }
                }
            }
            else
            {
              
                inputText = inputText.Substring(0, inputText.Length - 1);
                for (int i = 0; i < inputText.Length; i += 2)
                {
                    string code = inputText.Substring(i, 2);
                    if (reversePolibiuszTable.ContainsKey(code))
                    {
                        decryptedText.Append(reversePolibiuszTable[code]);
                    }
                    else
                    {
                        decryptedText.Append(code);
                    }
                }
            }

            DecryptedTextBox.Text = decryptedText.ToString();
        }
        private void ClearEncryptedText_Click(object sender, RoutedEventArgs e)
        {
            EncryptedTextBox.Clear();
        }

        private void ClearDecryptedText_Click(object sender, RoutedEventArgs e)
        {
            DecryptedTextBox.Clear();
        }
    }
}
