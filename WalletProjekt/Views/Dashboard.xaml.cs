﻿using System;
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

namespace WalletProjekt.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            
            InitializeComponent();

            
            //var parent = VisualTreeHelper.GetParent(this);
            //while (!(parent is Page))
            //{
            //    parent = VisualTreeHelper.GetParent(parent);
            //}
            //(parent as MainMenu)
        }
    }
   
}
