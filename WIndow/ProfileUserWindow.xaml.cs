using FreeWPF.data.api;
using FreeWPF.data.api.model;
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

namespace FreeWPF.WIndow
{
    /// <summary>
    /// Interaction logic for ProfileUserWindow.xaml
    /// </summary>
    public partial class ProfileUserWindow : Window
    {
        User User;
        public ProfileUserWindow()
        {
            InitializeComponent();
            update();
            //tbName.Text = User.FirstName;
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void mouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void addHours(object sender, RoutedEventArgs e)
        {
            new AddHoursWindow().ShowDialog() ;
            update();
        }

        void update()
        {
            var api = new NetworkApi();
            User = api.getUser();

            DataContext = User;
        }
    }
}
