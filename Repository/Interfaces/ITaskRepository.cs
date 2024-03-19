using SystemTasks.Models;

namespace SystemTasks.Repository.Interfaces {
    public interface ITaskRepository {

        Task<List<TaskModel>> FindAllTasks();
        Task<TaskModel> FindById(int id);   
        Task<TaskModel> CreateTasks(TaskModel task);
        Task<TaskModel> UpdateTasks(TaskModel task, int id);
        Task<bool> DeleteTasks(int id);
    }
}
