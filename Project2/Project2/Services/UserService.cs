using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;
using Project2.Models;
using Project2.Repositories;
using Project2.Services.interfaces;

namespace Project2.Services
{
    public class UserService(IUserRepository _repository) : IUserService
    {
        public Task<IEnumerable<UserModel>> GetAllUsers() => _repository.GetAllUsers();
        public Task<UserModel?> GetUserById(int id) => _repository.GetUserById(id);
        public Task<int> CreateUser(UserModel user) => _repository.Create(user);
        public Task<int> DeleteUser(int id) => _repository.Delete(id);
        public Task<int> UpdateUser(UserModel user) => _repository.Update(user);
    }
}
