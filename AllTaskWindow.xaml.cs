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
    /// Логика взаимодействия для AllTaskWindow.xaml
    /// </summary>
    public partial class AllTaskWindow : Window
    {
        AppContext appContext;
        public AllTaskWindow()
        {
            InitializeComponent();
            appContext = new AppContext();
            appContext.UserTasks.Load();
            this.DataContext = appContext.UserTasks.Local.ToBindingList();
        }

        private void usersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (taskList.SelectedItem == null) return;
            UserTask userTask = taskList.SelectedItem as UserTask;
            User user = appContext.Users.Where(item => item.Id == userTask.UserId).FirstOrDefault();
            MessageBox.Show($"Задача для: {user.Name} {user.Surname}\n" + userTask.TaskText, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
