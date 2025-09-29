using Project2.Models;
namespace Project2.Services.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel?> GetUserById(int id);
        Task<int> Create(UserModel user);
        Task<int> Update(UserModel user);
        Task<int> Delete(int id);
    }
}
