using test.Models;

namespace test.Services.interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        public Task<UserModel?> GetUserById(int id);

        public Task<int> CreateUser(UserModel user);

        public Task<int> DeleteUser(int id);

        public Task<int> UpdateUser(UserModel user);
    }
}
