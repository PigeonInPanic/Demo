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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {

        private Агенты _currentAgent = new Агенты();

        public AddEdit( Агенты selectedAgent )
        {
            InitializeComponent();

            if (selectedAgent != null) _currentAgent = selectedAgent;

            DataContext = _currentAgent;
        }


        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrameBase.GoBack();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentAgent.Тип_агента)) errors.AppendLine("Заполните поле Тип агента");
            if (string.IsNullOrWhiteSpace(_currentAgent.Наименование_агента)) errors.AppendLine("Заполните поле Наименование агента");
            if (string.IsNullOrWhiteSpace(_currentAgent.Электронная_почта_агента)) errors.AppendLine("Заполните поле Электронная почта агента");
            if (string.IsNullOrWhiteSpace(_currentAgent.Телефон_агента)) errors.AppendLine("Заполните поле Телефон агента");
            if (string.IsNullOrWhiteSpace(_currentAgent.Логотип_агента)) errors.AppendLine("Заполните поле Логотип агента");
            if (string.IsNullOrWhiteSpace(_currentAgent.Юридический_адрес)) errors.AppendLine("Заполните поле Юридический адрес");
            if (_currentAgent.Приоритет > 10000 || _currentAgent.Приоритет <= 1) errors.AppendLine("Заполните поле Приоритет");
            if (string.IsNullOrWhiteSpace(_currentAgent.Директор)) errors.AppendLine("Заполните поле Директор");
            if (_currentAgent.ИНН < 0) errors.AppendLine("Заполните поле ИНН");
            if (_currentAgent.КПП < 0) errors.AppendLine("Заполните поле КПП");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAgent.ID_Агента == 0)
            {
                BaseModel.GetContext().Агенты.Add(_currentAgent);

                try
                {
                    BaseModel.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.FrameBase.GoBack();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
