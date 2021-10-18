using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Model
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public string ImxPost { get; set; }
        public int IdUser { get; set; }
    }
}
