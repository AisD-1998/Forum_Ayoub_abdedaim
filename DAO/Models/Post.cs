using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Contenu { get; set; }
        public DateTime Date { get; set; }

        // Foreign Key to represent the relationship
        public int UtilisateurId { get; set; }

        // Navigation property to the Utilisateur
        public Utilisateur Utilisateur { get; set; } = null!;
    }
}

