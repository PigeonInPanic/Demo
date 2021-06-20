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

namespace NameCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameDataBase.Navigate(new AgentPage());

            Manager.FrameBase = FrameDataBase;
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.Navigate(new Supply());
        }

        private void RealiButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.Navigate(new Implementation());
        }

        private void AgentButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.Navigate(new AgentPage());
        }
    }
}
