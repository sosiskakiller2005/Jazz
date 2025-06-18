using Jazz.AppData;
using Jazz.Model;
using Jazz.Views.Windows;
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

namespace Jazz.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        private JazzDbEntities _context = App.GetContext();
        public SchedulePage()
        {
            InitializeComponent();
            ScheduleDg.ItemsSource = _context.Schedule.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditScheduleWindow addEditScheduleWindow = new AddEditScheduleWindow();
            addEditScheduleWindow.ShowDialog();
            if (addEditScheduleWindow.DialogResult == true)
            {
                ScheduleDg.ItemsSource = App.GetContext().Schedule.ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDg.SelectedItem != null)
            {
                if (MessageBoxHelper.Question("Удалить выбранную запись?"))
                {
                    Schedule selectedSchedule = ScheduleDg.SelectedItem as Schedule;
                    _context.Schedule.Remove(selectedSchedule);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Расписание успешно удалено!");
                    ScheduleDg.ItemsSource = App.GetContext().Schedule.ToList();
                }
            }
            else
            {
                MessageBoxHelper.Error("Выберите расписание для удаления!");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDg.SelectedItem == null)
            {
                MessageBoxHelper.Error("Выберите расписание!");
            }
            else
            {
                AddEditScheduleWindow addEditScheduleWindow = new AddEditScheduleWindow(ScheduleDg.SelectedItem as Schedule);
                addEditScheduleWindow.ShowDialog();
                if (addEditScheduleWindow.DialogResult == true)
                {
                    ScheduleDg.ItemsSource = App.GetContext().Schedule.ToList();
                }
            }
        }
    }
}
