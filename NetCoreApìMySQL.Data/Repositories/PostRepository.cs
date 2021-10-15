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
    public class PostRepository:IPostRepository
    {

        public MySQLConfiguration _connectionString { get; set; }

        public PostRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString._connectionString);
            // El segundo _connect... Hace referencia al parametro de la clase MySQLConfiguration
        }


        public async Task<bool> DeletePostAsync(Post Post)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM post WHERE idPost = @IdPost";

            var result = await db.ExecuteAsync(sql, new { IdPost = Post.IdPost }); // Ojo aqui con el Id que puede ser idUser
            return result > 0;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM post";

            return await db.QueryAsync<Post>(sql, new { });
        }

        public async Task<Post> GetPostDetailsAsync(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM post WHERE idPost = @IdPost";

            return await db.QueryFirstOrDefaultAsync<Post>(sql, new { IdPost = id }); // ojo aqui con el Id que puede ser idUser
        }

        public async Task<bool> InsertPostAsync(Post post)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO post (imxPost, idUser)
                        VALUES (@ImxPost, @IdUser)";

            var result = await db.ExecuteAsync(sql, new { post.ImxPost, post.IdUser});

            return result > 0;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE post
                        SET imxPost = @ImxPost, idUser = @IdUser
                        WHERE idPost = @IdPost";

            var result = await db.ExecuteAsync(sql, new { post.ImxPost, post.IdUser, post.IdPost});

            return result > 0;
        }

    }
}
