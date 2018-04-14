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

namespace LogicielEscapade
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            Button button = new Button();

            button.Content = "ok";
            button.Click += Button_Click;

            grid.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connection c = new Connection();
            ((Button)sender).Content = c.Select("client")[0];
        }
    }
}
