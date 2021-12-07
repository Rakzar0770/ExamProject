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
    /// Логика взаимодействия для UserTaskViewWindow.xaml
    /// </summary>
    public partial class UserTaskViewWindow : Window
    {
        AppContext appContext;
        
        public UserTaskViewWindow(User user)
        {
            InitializeComponent();
            UserT.Text = $"Задачи сотрудника: {user.Name} {user.Surname}";
            appContext = new AppContext();
            appContext.UserTasks.Where(item => item.UserId == user.Id).Load();
            this.DataContext = appContext.UserTasks.Local.ToBindingList();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem == null) return;
            // получаем выделенный объект
            UserTask userTask = taskList.SelectedItem as UserTask;
            appContext.UserTasks.Remove(userTask);
            appContext.SaveChanges();
        }

        private void taskList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (taskList.SelectedItem == null) return;
            UserTask userTask = taskList.SelectedItem as UserTask;
            MessageBox.Show(userTask.TaskText, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
