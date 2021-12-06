using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ExamProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext appContext;
        public MainWindow()
        {
            InitializeComponent();
            appContext = new AppContext();
            appContext.Users.Load();
            this.DataContext = appContext.Users.Local.ToBindingList();
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginText.Text.Trim();
            string pass = PassText.Password.Trim();
            User user = appContext.Users.Where(item => item.Login == login && item.Pass == pass).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("Вы ввели что-то неправильно!");
            }
            else
            {
                if(user.IsAdmin == "Admin")
                {
                    AdminPanel adminPanel = new AdminPanel(user);
                    adminPanel.Show();
                    Close();
                }
                else
                {
                    UserPanelWindow userPanel = new UserPanelWindow(user);
                    userPanel.Show();
                    Close();
                }
            }
        }
    }
}
