using CaffCalc.CodeBehind;
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
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Button acceptChanges_Button = new Button();
        public ProfilePage()
        {
            InitializeComponent();
            UserFromFile();

            name_TextBox.Text = BackendDB.User.Name;
            surname_TextBox.Text = BackendDB.User.Surname;
            weight_TextBox.Text = BackendDB.User.WeightKg.ToString();
            acceptChanges_Button.Content = "Zatwierdź";
            acceptChanges_Button.Click += acceptChanges_Button_Click;
        }


        private void edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(edit_Button.Content.ToString() == "Edytuj")
            {
                name_TextBox.IsReadOnly = false;
                surname_TextBox.IsReadOnly = false;
                weight_TextBox.IsReadOnly = false;

                edit_Button.Content = "Odrzuć";
                profile_StackPanel.Children.Add(acceptChanges_Button);
            }
            else if(edit_Button.Content.ToString() == "Odrzuć")
            {
                name_TextBox.IsReadOnly = true;
                surname_TextBox.IsReadOnly = true;
                weight_TextBox.IsReadOnly = true;

                name_TextBox.Text = User.Name;
                surname_TextBox.Text = User.Surname;
                weight_TextBox.Text = User.WeightKg.ToString();

                edit_Button.Content = "Edytuj";
                profile_StackPanel.Children.Remove(acceptChanges_Button);
            }
        }
        private void acceptChanges_Button_Click(object sender, RoutedEventArgs e)
        {
            User.Name = name_TextBox.Text;
            User.Surname = surname_TextBox.Text;
            int.TryParse(weight_TextBox.Text, out User.WeightKg);

            name_TextBox.IsReadOnly = true;
            surname_TextBox.IsReadOnly = true;
            weight_TextBox.IsReadOnly = true;
            edit_Button.Content = "Edytuj";

            profile_StackPanel.Children.Remove(acceptChanges_Button);
            UserToFile();
        }
    }
}
