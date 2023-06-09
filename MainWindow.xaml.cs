﻿using FreeWPF.data.api;
using FreeWPF.data.api.model;
using FreeWPF.pages;
using FreeWPF.WIndow;
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

namespace FreeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frMain.Navigate(new pgAuth());
        }

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        
        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        

        private void SungUpUser(object sender, RoutedEventArgs e)
        {
            new registrationUser().Show();
        }
    }
}
