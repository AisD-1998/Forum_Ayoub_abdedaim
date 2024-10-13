using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public required string Log { get; set; }
        public required string Pass { get; set; }

        // Navigation property to represent a collection of posts
        public List<Post> Posts { get; set; } = new();
    }
}
