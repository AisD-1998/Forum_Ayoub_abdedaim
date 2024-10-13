using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PostsService
{
    public interface IPost
    {
        public int addPost(Post ct);
        public Post FindById(int id);
        public List<Post> allposts();
        public Post? updatePost(Post ct, int idc);
        public Post? deletePost(int idc);
    }
}
