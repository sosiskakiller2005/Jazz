using Jazz.AppData;
using Jazz.Model;
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

namespace Jazz.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditScheduleWindow.xaml
    /// </summary>
    public partial class AddEditScheduleWindow : Window
    {
        Schedule _selectedSchedule;
        private JazzDbEntities _context = App.GetContext();
        public AddEditScheduleWindow()
        {
            InitializeComponent();
            EditBtn.Visibility = Visibility.Collapsed;
            StudentCmb.ItemsSource = _context.Student.ToList();
            StudentCmb.DisplayMemberPath = "Fullname";
            ServiceCmb.ItemsSource = _context.Service.ToList();
            ServiceCmb.DisplayMemberPath = "Name";
            UserCmb.ItemsSource = _context.User.ToList();
            UserCmb.DisplayMemberPath = "Login";
        }
        public AddEditScheduleWindow(Schedule selectedSchedule)
        {
            InitializeComponent();
            ScheduleGr.DataContext = selectedSchedule;
            _selectedSchedule = selectedSchedule;
            AddBtn.Visibility = Visibility.Collapsed;
            StudentCmb.ItemsSource = _context.Student.ToList();
            StudentCmb.DisplayMemberPath = "Fullname";
            ServiceCmb.ItemsSource = _context.Service.ToList();
            ServiceCmb.DisplayMemberPath = "Name";
            UserCmb.ItemsSource = _context.User.ToList();
            UserCmb.DisplayMemberPath = "Login";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentCmb.SelectedItem != null && ServiceCmb.SelectedItem != null && UserCmb.SelectedItem != null)
            {
                Schedule newSchedule = new Schedule()
                {
                    Student = StudentCmb.SelectedItem as Student,
                    Service = ServiceCmb.SelectedItem as Service,
                    User = UserCmb.SelectedItem as User,
                    DateTimeOfAppointment = (DateTime)DateDp.SelectedDate,
                };
                _context.Schedule.Add(newSchedule);
                _context.SaveChanges();
                MessageBoxHelper.Information("Расписание успешно добавлено!");
                DialogResult = true;
            }
            else
            {
                MessageBoxHelper.Error("Пожалуйста, заполните все поля!");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentCmb.SelectedItem != null && ServiceCmb.SelectedItem != null && UserCmb.SelectedItem != null)
            {
                _selectedSchedule.Student = StudentCmb.SelectedItem as Student;
                _selectedSchedule.Service = ServiceCmb.SelectedItem as Service;
                _selectedSchedule.User = UserCmb.SelectedItem as User;
                _selectedSchedule.DateTimeOfAppointment = (DateTime)DateDp.SelectedDate;
                _context.SaveChanges();
                MessageBoxHelper.Information("Расписание успешно изменено!");
                DialogResult = true;
            }
            else
            {
                MessageBoxHelper.Error("Пожалуйста, заполните все поля!");
            }
        }
    }
}
