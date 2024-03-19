using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SystemTasks.Data;
using SystemTasks.Models;
using SystemTasks.Repository.Interfaces;

namespace SystemTasks.Repository {
    public class UserRepository : IUserRepository {
        private readonly SystemTasksDBContext _dbContext;
        public UserRepository(SystemTasksDBContext systemTasksDBContext) {
            _dbContext = systemTasksDBContext;
        }

        public async Task<List<UserModel>> FindAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindById(int id) {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> CreateUser(UserModel user) {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id) {
            UserModel userByID = await FindById(id);
            if (userByID == null) {
                throw new Exception($"User: {id} does not exists in database.");
            }

            userByID.Name = user.Name;
            userByID.Email = user.Email;

            _dbContext.Users.Update(userByID);
            await _dbContext.SaveChangesAsync();

            return userByID;

        }


        public async Task<bool> DeleteUser(int id) {
            UserModel userByID = await FindById(id);
            if (userByID == null) {
                throw new Exception($"User: {id} does not exists in database.");
            }
            _dbContext.Users.Remove(userByID);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
