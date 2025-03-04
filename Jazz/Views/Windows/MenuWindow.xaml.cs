using Jazz.Views.Pages;
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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(MainBtn.Name);
        }

        private void ServicesBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(ServicesBtn.Name);
        }

        private void ArchiveBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(ArchiveBtn.Name);
        }

        private void StudentsBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(StudentsBtn.Name);
            MainFrm.Navigate(new StudentsPage());
        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(ScheduleBtn.Name);
        }

        private void AppointmentsBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeColor(AppointmentsBtn.Name);
        }

        private void ChangeColor(string name)
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(MainBtn);
            buttons.Add(ServicesBtn);
            buttons.Add(ArchiveBtn);
            buttons.Add(StudentsBtn);
            buttons.Add(ScheduleBtn);
            buttons.Add(AppointmentsBtn);

            foreach (Button btn in buttons)
            {
                if (btn.Name == name)
                {
                    btn.Background = new SolidColorBrush(Color.FromRgb(115, 237, 200));
                    btn.Style = (Style)FindResource("PressedBtn");
                }
                else
                {
                    btn.Background = new SolidColorBrush(Color.FromRgb(229, 229, 229));
                    btn.Style = (Style)FindResource("UnpressedBtn");
                }
            }
        }
    }
}
