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
using WalletProjekt.ViewModels;
using WalletProjekt.Views;

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void PizzaCheckBoxRegistrationForm_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dayuum mate, You just won a free pizza ");
        }

        private void BackFromRegistrationForm_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Page))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            (parent as LoginPage).CenterView.Width = 350;
            (parent as LoginPage).LoginRegisterViewLogin();
            
        }
    }
}
