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
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy DataCollectionWindow.xaml
    /// </summary>
    public partial class DataCollectionWindow : Window
    {
        public DataCollectionWindow()
        {
            InitializeComponent();
        }

        private void accept_Button_Click(object sender, RoutedEventArgs e)
        {
            User.Name = name_TextBox.Text;
            User.Surname = surname_TextBox.Text;
            int.TryParse(weight_TextBox.Text, out User.WeightKg);
            UserToFile();

            Close();
        }

        private void Letters_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Text) && !char.IsLetter(e.Text[0]))
            {
                e.Handled = true; // Disallow non-letter input
            }
        }

        private void Numbers_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(e.Text) && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }
    }
}
