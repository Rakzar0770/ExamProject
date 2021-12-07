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
using System.Windows.Shapes;

namespace ExamProject
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        AppContext appContext;
        bool IsOpenClose = false;
        public AdminPanel(User user)
        {
            InitializeComponent();
            appContext = new AppContext();
            appContext.Users.Where(item => item.Id != user.Id).Load();
            this.DataContext = appContext.Users.Local.ToBindingList();
            usersList.Visibility = Visibility.Collapsed;
            ButtonsPanel.Visibility = Visibility.Collapsed;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPanel addPanel = new AddPanel(new User());
            if (addPanel.ShowDialog() == true)
            {
                User user = addPanel.User;
                appContext.Users.Add(user);
                appContext.SaveChanges();
            }
        }

        private void TakeTask_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem == null) return;
            User user = usersList.SelectedItem as User;
            TakeTaskWindow takeTaskWindow = new TakeTaskWindow(user);
            takeTaskWindow.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem == null) return;
            // получаем выделенный объект
            User user = usersList.SelectedItem as User;
            appContext.Users.Remove(user);
            appContext.SaveChanges();
        }

        private void UserListOpen_Click(object sender, RoutedEventArgs e)
        {
            IsOpenClose = !IsOpenClose;
            if (IsOpenClose)
            {
                usersList.Visibility = Visibility.Visible;
                ButtonsPanel.Visibility = Visibility.Visible;
            }
            else
            {
                usersList.Visibility = Visibility.Collapsed;
                ButtonsPanel.Visibility = Visibility.Collapsed;
            }

        }

        private void ShowTaskUser_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem == null) return;
            User user = usersList.SelectedItem as User;
            UserTaskViewWindow userTaskView = new UserTaskViewWindow(user);
            userTaskView.ShowDialog();
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem == null) return;
            // получаем выделенный объект
            User user = usersList.SelectedItem as User;

            ReplaceWindow replace = new ReplaceWindow(new User
            {
                Id = user.Id,
                Login = user.Login,
                Pass = user.Pass,
                Name = user.Name,
                Surname = user.Surname,
                IsAdmin = user.IsAdmin
            });

            if (replace.ShowDialog() == true)
            {
                // получаем измененный объект
                user = appContext.Users.Find(replace.User.Id);
                if (user != null)
                {
                    user.Login = replace.User.Login;
                    user.Pass = replace.User.Pass;
                    user.Name = replace.User.Name;
                    user.Surname = replace.User.Surname;
                    user.IsAdmin = replace.User.IsAdmin;
                    appContext.Entry(user).State = EntityState.Modified;
                    appContext.SaveChanges();
                }
            }
        }

        private void AllTask_Click(object sender, RoutedEventArgs e)
        {
            AllTaskWindow allTask = new AllTaskWindow();
            allTask.ShowDialog();
        }
    }
}
