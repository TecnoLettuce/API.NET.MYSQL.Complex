using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Model
{
    public class Like
    {
        [Key]
        public int IdLike { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }

        public int IdPost { get; set; }
        [ForeignKey("IdPost")]
        public Post Post { get; set; }
    }
}