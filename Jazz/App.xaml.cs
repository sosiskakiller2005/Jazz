using Jazz.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Jazz
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static JazzDbEntities _context;
        public static JazzDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new JazzDbEntities();
            }
            return _context;
        }
    }
}
