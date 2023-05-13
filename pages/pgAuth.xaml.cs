using FreeWPF.data.api.model;
using FreeWPF.data.api;
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

namespace FreeWPF.pages
{
    /// <summary>
    /// Interaction logic for pgAuth.xaml
    /// </summary>
    public partial class pgAuth : Page
    {
        public pgAuth()
        {
            InitializeComponent();
        }

        private void SungUpUser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgRegi());
        }

        private void EnterUser(object sender, RoutedEventArgs e)
        {
            var api = new NetworkApi();

            var response = api.auth(new AuthBody
            {
                FirstName = tbName.Text,
                LastName = tbSurName.Text,
                Password = pbPassword.Password
            });
            if (response.Access_token != "")
            {
                var UserRespose = api.getUser();
                Application.Current.MainWindow.Hide();
                new ProfileUserWindow().ShowDialog();
                Application.Current.MainWindow.Close();
                tbName.Text = "";
                tbSurName.Text = "";
                pbPassword.Password = "";
            }
            else
                MessageBox.Show("Error");
        }
    }
}
