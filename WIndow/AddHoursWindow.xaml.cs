using FreeWPF.data.api;
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
    /// Interaction logic for AddHoursWindow.xaml
    /// </summary>
    public partial class AddHoursWindow : Window
    {
        public AddHoursWindow()
        {
            InitializeComponent();
        }

        private void addHour(object sender, RoutedEventArgs e)
        {
            var api = new NetworkApi();
            
            if (tbHours.Text != "")
            {
                int hour = Convert.ToInt32(tbHours.Text);
                api.updateBalance(hour);

            }
            Close();
        }

        private void mouseDowns(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void closeWindow(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
