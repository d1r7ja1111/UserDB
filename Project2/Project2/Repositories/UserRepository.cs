using Dapper;
using Microsoft.Data.SqlClient;
using Project2.Models;
using Project2.Services.interfaces;

namespace Project2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using var db = CreateConnection();
            return await db.QueryAsync<UserModel>("SELECT * FROM Users");
        }

        public async Task<UserModel?> GetUserById(int id)
        {
            using var db = CreateConnection();
            return await db.QueryFirstOrDefaultAsync<UserModel>(
                "SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> Create(UserModel user)
        {
            using var db = CreateConnection();
            var sql = @"
                INSERT INTO Users (name, surname, personal_code, start_date, end_date)
                VALUES (@name, @surname, @personal_code, @start_date, @end_date);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await db.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<int> Update(UserModel user)
        {
            using var db = CreateConnection();
            var sql = @"
                UPDATE Users
                SET name=@name, surname=@surname, personal_code=@personal_code, start_date=@start_date, end_date=@end_date
                WHERE Id=@Id";
            return await db.ExecuteAsync(sql, user);
        }

        public async Task<int> Delete(int id)
        {
            using var db = CreateConnection();
            return await db.ExecuteAsync("DELETE FROM Users WHERE Id=@Id", new { Id = id });
        }
    }
}
