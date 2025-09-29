using RestEase;
using test.Models;

public interface IDbApi
{
    [Get("api/DbUser")]
    Task<IEnumerable<UserModel>> GetAllUsers([Query] int page = 1, [Query] int pageSize = 10);

    [Get("api/DbUser/{id}")]
    Task<UserModel> GetUserById([Path] int id);

    [Post("api/DbUser")]
    Task<UserModel> CreateUser([Body] UserModel user);

    [Put("api/DbUser/{id}")]
    Task UpdateUser([Path] int id, [Body] UserModel user);

    [Delete("api/DbUser/{id}")]
    Task DeleteUser([Path] int id);
}
