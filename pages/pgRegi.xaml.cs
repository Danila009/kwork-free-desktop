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
    /// Interaction logic for pgRegi.xaml
    /// </summary>
    public partial class pgRegi : Page
    {
        public pgRegi()
        {
            InitializeComponent();
            var api = new NetworkApi();
            List<Specialization> specializations = api.getSpecializations();
            cbSpecialization.ItemsSource = specializations;
        }

        private void enterSing(object sender, RoutedEventArgs e)
        {
            var api = new NetworkApi();
            if (pbPassword1.Password == pbPassword2.Password)
            {
                var response = api.reag(new RegistrationBody
                {
                    FirstName = tbName.Text,
                    LastName = tbSurName.Text,
                    Password = pbPassword1.Password,
                    SpecializationId = cbSpecialization.SelectedIndex + 1

                });
                if (response.Access_token != "")
                {
                    var UserRespose = api.getUser();
                    Application.Current.MainWindow.Hide();
                    new ProfileUserWindow().ShowDialog();
                    Application.Current.MainWindow.Close();
                    tbName.Text = "";
                    tbSurName.Text = "";
                    pbPassword1.Password = "";
                    pbPassword2.Password = "";
                }
                else
                    MessageBox.Show("Error");
            }
            else
            {
                pbPassword1.BorderBrush = Brushes.Red;
                pbPassword2.BorderBrush = Brushes.Red;
            }
        }

        private void clAuth(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgAuth());
        }
        /* 
new ProfileUserWindow().ShowDialog();*/
    }
}
