using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;
using test.Models;
using test.Repositories;
using test.Services.interfaces;

namespace test.Services
{
    public class UserService(IDbApi _dbApi) : IUserService
    {
        public Task<IEnumerable<UserModel>> GetAllUsers() => _dbApi.GetAllUsers();
        public Task<UserModel?> GetUserById(int id) => _dbApi.GetUserById(id);
        public async Task<int> CreateUser(UserModel user)
        {
            var created = await _dbApi.CreateUser(user);
            return created.Id;
        }
        public async Task<int> DeleteUser(int id)
        {
            await _dbApi.DeleteUser(id);
            return id;
        }
        public async Task<int> UpdateUser(UserModel user)
        {
            await _dbApi.UpdateUser(user.Id, user);
            return user.Id;
        }
    }
}

