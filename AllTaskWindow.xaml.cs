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
    }
}
