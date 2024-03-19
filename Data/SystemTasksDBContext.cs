using Microsoft.EntityFrameworkCore;
using SystemTasks.Data.Map;
using SystemTasks.Models;

namespace SystemTasks.Data {
    public class SystemTasksDBContext: DbContext {

        public SystemTasksDBContext(DbContextOptions<SystemTasksDBContext> options): base(options) { 
            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
