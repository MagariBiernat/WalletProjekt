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
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using WalletProjekt.Classes;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Interaction logic for Profit.xaml
    /// </summary>
    /// 
    
    public partial class Profit : UserControl
    {
        UserData user;

        string[] categories = new string[] { "Food", "House", "Transport", "Fun", "Income", "Investment", "Vehicle" };
        public Profit()
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
            // nothing   
        }
        private void ProfitSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (AmountTextBox.Text != "")
            {
                int Amount = Convert.ToInt32(AmountTextBox.Text);
                string desc = DescriptionVar.Text.ToString();
                Classes.Posts post = new Classes.Posts();

                bool result = post.AddNewPost(Amount, "profit", "yes",  desc, user.email, user.userId);
                if (result)
                {
                    UpdateBalance(Amount);

                    MessageBox.Show("Post has been added.");
                }
                else
                    MessageBox.Show("An error occured.");   
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
        private void AmountTextBox_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }
    }
}
