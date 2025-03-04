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
    /// Логика взаимодействия для AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        private JazzDbEntities _context = App.GetContext();
        private Student _student;
        public AddEditStudentWindow()
        {
            InitializeComponent();
            EditBtn.Visibility = Visibility.Collapsed;
        }
        public AddEditStudentWindow(Student selectedStudent)
        {
            InitializeComponent();
            _student = selectedStudent;
            StudentGrid.DataContext = selectedStudent;
            AddBtn.Visibility = Visibility.Collapsed;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FullnameTb.Text) && BirthdayDp.SelectedDate != null)
            {
                Student newStudent = new Student()
                {
                    Fullname = FullnameTb.Text,
                    Birthday = BirthdayDp.SelectedDate.Value
                };
                _context.Student.Add(newStudent);
                _context.SaveChanges();
                MessageBoxHelper.Information("Студент успешно добавлен!");
                Close();
            }
            else
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FullnameTb.Text) && BirthdayDp.SelectedDate != null)
            {
                _student.Fullname = FullnameTb.Text;
                _student.Birthday = BirthdayDp.SelectedDate.Value;
                _context.SaveChanges();
                MessageBoxHelper.Information("Данные студента успешно изменены!");
                Close();
            }
            else
            {
                MessageBoxHelper.Warning("Заполните все поля!");
            }
        }
    }
}
