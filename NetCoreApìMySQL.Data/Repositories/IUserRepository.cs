using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAlllUsersAsync();
        Task<User> GetUserDetailsAsync (int id);
        Task<bool> InsertUserAsync (User user);
        Task<bool> UpdateUserAsync (User user);
        Task<bool> DeleteUserAsync (User user);
    }
}
