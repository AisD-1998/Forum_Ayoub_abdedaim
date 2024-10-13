using DAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ForumDbcontext : DbContext
    {
        public ForumDbcontext(DbContextOptions<ForumDbcontext> options)
           : base(options)

        { }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<Post> posts { get; set; }

    }

}

