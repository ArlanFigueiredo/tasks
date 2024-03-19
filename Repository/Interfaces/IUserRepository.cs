using SystemTasks.Models;

namespace SystemTasks.Repository.Interfaces {
    public interface IUserRepository {

        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindById(int id);   
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
