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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private JazzDbEntities _context = App.GetContext();
        public StudentsPage()
        {
            InitializeComponent();
            StudentsDg.ItemsSource = _context.Student.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow();
            addEditStudentWindow.ShowDialog();
            if (addEditStudentWindow.DialogResult == true)
            {
                StudentsDg.ItemsSource = App.GetContext().Student.ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDg.SelectedItem as Student == null)
            {
                MessageBoxHelper.Warning("Выберите студента!");
            }
            else
            {
                if (MessageBoxHelper.Question("Удалить выбранного ученика?"))
                {
                    Student selectedStudent = StudentsDg.SelectedItem as Student;
                    _context.Student.Remove(selectedStudent);
                    _context.SaveChanges();
                    StudentsDg.ItemsSource = _context.Student.ToList();
                    MessageBoxHelper.Information("Студент успешно удален!");
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDg.SelectedItem as Student == null)
            {
                MessageBoxHelper.Warning("Выберите студента!");
            }
            else
            {
                AddEditStudentWindow addEditStudentWindow = new AddEditStudentWindow(StudentsDg.SelectedItem as Student);
                addEditStudentWindow.ShowDialog();
                if (addEditStudentWindow.DialogResult == true)
                {
                    StudentsDg.ItemsSource = _context.Student.ToList();
                }
            }
        }
    }
}
