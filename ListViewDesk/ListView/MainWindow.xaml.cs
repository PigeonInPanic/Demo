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

namespace ListView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var currentAgent = BaseEntities.GetContext().Агенты.ToList();

            ListViewBase.ItemsSource = currentAgent;
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Руслан\Desktop\Ready\Demo\import(Отредаченное)\agents_k_import.txt");
            var Images = Directory.GetFiles(@"C:\Users\Руслан\Desktop\Ready\Demo\agents");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempAgent = new Агенты { }
            }
        }
    }
}
