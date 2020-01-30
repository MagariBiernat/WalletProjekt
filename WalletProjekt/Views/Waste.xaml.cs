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
using WalletProjekt.Classes;
using System.Text.RegularExpressions;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Interaction logic for Waste.xaml
    /// </summary>
    public partial class Waste : UserControl
    {
        UserData user;
        string[] categories = new string[] { "Food", "House", "Transport", "Fun", "Income", "Investment", "Vehicle" };
        public Waste()
        {
            GetUser();
            InitializeComponent();
        }
        private void GetUser()
        {
            user = ((MainWindow)App.Current.MainWindow).GetUserData();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                CategoriesCombobox.Items.Add(categories[i]);
            }
        }
        private void WasteSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (AmountTextBox.Text != "")
            {
                if (CategoriesCombobox.SelectedIndex > -1)
                {
                    int Amount = Convert.ToInt32(AmountTextBox.Text);
                    Amount *= -1;
                    
                    string category = CategoriesCombobox.SelectedValue.ToString();
                    string desc = DescriptionVar.Text.ToString();
                    Classes.Posts post = new Classes.Posts();

                    bool result = post.AddNewPost(Amount, category, "no", desc, user.email, user.userId);
                    if (result)
                    {
                        UpdateBalance(Amount);
                        var info = new Info();
                        MaterialDesignThemes.Wpf.DialogHost.Show(info);
                    }
                    else
                        MessageBox.Show("An error occured.");
                }
            }
        }
        private void UpdateBalance(float amount)
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Page))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            (parent as MainMenu).UpdateBalance(amount);
        }
    }
}
