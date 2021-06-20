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
    /// Логика взаимодействия для Implementation.xaml
    /// </summary>
    public partial class Implementation : Page
    {
        public Implementation()
        {
            InitializeComponent();
            DataGridBase.ItemsSource = BaseModel.GetContext().Реализация.ToList();
        }
    }
}
