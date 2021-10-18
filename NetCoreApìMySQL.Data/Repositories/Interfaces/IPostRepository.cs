using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public interface IPostRepository
    {
        Task<bool> DeletePostAsync(Post Post);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostDetailsAsync(int id);
        Task<bool> InsertPostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
    }
}
