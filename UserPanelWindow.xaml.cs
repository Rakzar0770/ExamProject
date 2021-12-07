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
    /// Логика взаимодействия для UserPanelWindow.xaml
    /// </summary>
    public partial class UserPanelWindow : Window
    {
        AppContext appContext;
        public UserPanelWindow(User user)
        {
            InitializeComponent();
            appContext = new AppContext();
            UserT.Text = $"Приветствую {user.Name} {user.Surname}. Твои задачи:";
            appContext.UserTasks.Where(item => item.UserId == user.Id).Load();
            this.DataContext = appContext.UserTasks.Local.ToBindingList();
        }

        private void taskList_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem == null) return;
            UserTask userTask = taskList.SelectedItem as UserTask;
            if (userTask.TaskAnotation.Contains("(Выполнено)"))
            {
                MessageBox.Show("Задание уже выполнено!");
            }
            else
            {
                userTask = appContext.UserTasks.Find(userTask.Id);
                userTask.TaskAnotation = userTask.TaskAnotation + " (Выполнено)";
                appContext.Entry(userTask).State = EntityState.Modified;
                appContext.SaveChanges();
                e.Handled = true;
            }
            
        }

        private void taskList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (taskList.SelectedItem == null) return;
            UserTask userTask = taskList.SelectedItem as UserTask;
            MessageBox.Show(userTask.TaskText,"Информация", MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
