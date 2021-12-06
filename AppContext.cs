using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ExamProject
{
    public class AppContext : DbContext
    {
        public AppContext(): base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

    }
}
