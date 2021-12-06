using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamProject
{
    public class UserTask: INotifyPropertyChanged
    {

        private string taskText;
        private string taskAnotation;
        public int UserId { get; set; }
        public int Id { get; set; }


        public string TaskText
        {
            get { return taskText; }
            set
            {
                taskText = value;
                OnPropertyChanged("TaskText");
            }
        }

        public string TaskAnotation
        {
            get { return taskAnotation; }
            set
            {
                taskAnotation = value;
                OnPropertyChanged("TaskAnotation");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
