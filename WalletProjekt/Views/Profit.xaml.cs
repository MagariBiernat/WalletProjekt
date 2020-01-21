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

namespace WalletProjekt.Views
{
    /// <summary>
    /// Interaction logic for Profit.xaml
    /// </summary>
    public partial class Profit : UserControl
    {
        string[] categories = new string[] { "Food", "House", "Transport", "Fun", "Income", "Investment", "Vehicle" };
        public Profit()
        {
            InitializeComponent();
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

        
    }
}
