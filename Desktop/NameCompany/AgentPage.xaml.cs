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
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.Navigate(new AddEdit(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BaseModel.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridBase.ItemsSource = BaseModel.GetContext().Агенты.ToList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.Navigate(new AddEdit((sender as Button).DataContext as Агенты));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var AgentForRemoving = DataGridBase.SelectedItems.Cast<Агенты>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {AgentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BaseModel.GetContext().Агенты.RemoveRange(AgentForRemoving);
                    BaseModel.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены");

                    DataGridBase.ItemsSource = BaseModel.GetContext().Агенты.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
