using Dapper;
using MySql.Data.MySqlClient;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public MySQLConfiguration _connectionString { get; set; }

        public UserRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString._connectionString);
            // El segundo _connect... Hace referencia al parametro de la clase MySQLConfiguration
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM user WHERE idUser = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = user.IdUser }); // Ojo aqui con el Id que puede ser idUser
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAlllUsersAsync()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM user";

            return await db.QueryAsync<User>(sql, new { });
        }

        public async Task<User> GetUserDetailsAsync(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM user WHERE idUser = @Id";

            return await db.QueryFirstOrDefaultAsync<User>(sql, new { Id = id }); // ojo aqui con el Id que puede ser idUser
        }

        public async Task<bool> InsertUserAsync(User user)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO user (userName, password)
                        VALUES (@UserName, @Password)";

            var result = await db.ExecuteAsync(sql, new { user.UserName, user.Password});

            return result > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE user
                        SET userName = @UserName, password = @Password
                        WHERE idUser = @IdUser";

            var result = await db.ExecuteAsync(sql, new { user.UserName, user.Password, user.IdUser});

            return result > 0;
        }
    }
}
