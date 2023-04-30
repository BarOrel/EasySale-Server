using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EasySale.Data
{
    public class Tasks_DbContext :DbContext
    {
        public Tasks_DbContext(DbContextOptions<Tasks_DbContext> options): base(options)
        {

        }
        
        public virtual DbSet<Models.TaskModel>? Tasks { get; set; }
        public virtual DbSet<Models.Department>? Depratments { get; set; }
    }
}
