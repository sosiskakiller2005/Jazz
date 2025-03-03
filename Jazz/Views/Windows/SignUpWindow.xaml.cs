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
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private JazzDbEntities _context = App.GetContext();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void AuthoriseHl_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text != string.Empty && PasswordPb.Password != string.Empty && RepeatPasswordTb.Password != string.Empty)
            {
                if (PasswordPb.Password == RepeatPasswordTb.Password)
                {
                    User newUser = new User
                    {
                        Email = EmailTb.Text,
                        Login = LoginTb.Text,
                        Password = PasswordPb.Password
                    };
                    _context.User.Add(newUser);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Вы успешно зарегистрировались!");
                    AuthorisationWindow authorisationWindow = new AuthorisationWindow();
                    authorisationWindow.Show();
                    Close();
                }
                else
                {
                    MessageBoxHelper.Error("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBoxHelper.Error("Заполните все поля!");
            }
        }
    }
}
