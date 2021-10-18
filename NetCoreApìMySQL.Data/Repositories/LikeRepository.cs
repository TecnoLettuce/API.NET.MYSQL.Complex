using NetCoreApiMySQL.Data.Repositories.Interfaces;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;

namespace NetCoreApiMySQL.Data.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        public MySQLConfiguration _connectionString { get; set; }

        public LikeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        
        protected MySqlConnection dbConnection() {
            return new MySqlConnection(_connectionString._connectionString);
        }

        public async Task<bool> DeleteLikeAsync(Like like)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM `like` WHERE idLike = @IdLike";

            var result = await db.ExecuteAsync(sql, new { IdLike = like.IdLike });
            
            return result > 0;
        }

        public async Task<IEnumerable<Like>> GetAllLikesAsync()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM `like`";

            return await db.QueryAsync<Like>(sql, new { });

        }

        public async Task<Like> GetLikeDetailsAsync(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM `like` WHERE idLike = @IdLike";

            return await db.QueryFirstOrDefaultAsync<Like>(sql, new { IdLike = id });
        }

        public async Task<IEnumerable<Like>> GetLikesByUserIdAsync(int userId)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM `like` 
                        NATURAL JOIN user 
                        RIGHT JOIN post ON post.idPost = like.idPost 
                        WHERE like.idUser = @IdUser";

            return await db.QueryAsync<Like>(sql, new { IdUser = userId });
        }

        public async Task<bool> InsertLikeAsync(Like like)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO `like` (idUser, idPost)
                      VALUES (@IdUser, @IdPost)";

            var result = await db.ExecuteAsync(sql, new { like.IdUser, like.IdPost });

            return result > 0;
        }

        public async Task<bool> UpdateLikeAsync(Like like)
        {
            var db = dbConnection();

            var sql = @"UPDATE `like`
                      SET idUser = @IdUser, idPost = @IdPost
                      WHERE idLike = @IdLike";

            var result = await db.ExecuteAsync(sql, new { like.IdUser, like.IdPost, like.IdLike });

            return result > 0;

        }
    }
}
