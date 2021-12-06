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

namespace ExamProject
{
    /// <summary>
    /// Логика взаимодействия для AddPanel.xaml
    /// </summary>
    public partial class AddPanel : Window
    {
        public User User { get; set; }
        public AddPanel( User u)
        {
            InitializeComponent();
            User = u;
            this.DataContext = User;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
