using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SystemTasks.Data;
using SystemTasks.Models;
using SystemTasks.Repository.Interfaces;

namespace SystemTasks.Repository {
    public class TaskRepository : ITaskRepository {
        private readonly SystemTasksDBContext _dbContext;
        public TaskRepository(SystemTasksDBContext systemTasksDBContext) {
            _dbContext = systemTasksDBContext;
        }

        public async Task<List<TaskModel>> FindAllTasks() {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> FindById(int id) {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> CreateTasks(TaskModel task) {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTasks(TaskModel task, int id) {
            TaskModel taskById = await FindById(id);
            if (taskById == null) {
                throw new Exception($"User: {id} does not exists in database.");
            }


            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;


            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;

        }


        public async Task<bool> DeleteTasks(int id) {
            TaskModel taskById = await FindById(id);
            if (taskById == null) {
                throw new Exception($"User: {id} does not exists in database.");
            }
            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
