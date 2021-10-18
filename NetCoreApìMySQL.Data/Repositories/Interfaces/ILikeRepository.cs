using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        Task<bool> DeleteLikeAsync(Like like);
        Task<IEnumerable<Like>> GetAllLikesAsync();
        Task<Like> GetLikeDetailsAsync(int id);
        Task<IEnumerable<Like>> GetLikesByUserIdAsync(int userId);
        Task<bool> InsertLikeAsync(Like like);
        Task<bool> UpdateLikeAsync(Like like);
    }
}
