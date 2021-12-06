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
    /// Логика взаимодействия для TakeTaskWindow.xaml
    /// </summary>
    public partial class TakeTaskWindow : Window
    {
        AppContext appContext;
        User user;
        public TakeTaskWindow( User us)
        {
            InitializeComponent();
            user = us;
            UserT.Text = $"Добавить задание для: {us.Name} {us.Surname}";
            appContext = new AppContext();
            appContext.UserTasks.Load();
            this.DataContext = appContext.UserTasks.Local.ToBindingList();
        }

        private void TakeTask_Click(object sender, RoutedEventArgs e)
        {
            UserTask userTask = new UserTask();
            userTask.UserId = user.Id;
            userTask.TaskAnotation= TaskText.Text.Trim();
            userTask.TaskText = FullText.Text.Trim();
            appContext.UserTasks.Add(userTask);
            appContext.SaveChanges();
            
        }
    }
}
