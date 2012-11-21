using sambit.DAL.Entities;
using sambit.DAL.Repositories;
using sambit.BLL.Base;
using sambit.BLL.Lib;
using sambit.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using WebMatrix.WebData;
using sambit.BLL.Entities.Base;

namespace sambit.BLL.Entities
{
    public class PostService : EntityBase, IPostService
    {
        private readonly IRepository<Post> _repository;

        public PostService(IRepository<Post> repository)
        {
            this._repository = repository;
            this._result = new BResult();
        }

        public sambit.BLL.Models.PostModel GetPost(int id)
        {
            var post = _repository.Find(id);

            if (post != null)
                return new sambit.BLL.Models.PostModel(post);
            else
                return new sambit.BLL.Models.PostModel();
        }

        public IList<sambit.BLL.Models.PostModel> GetPosts()
        {
            var posts = _repository.Get().Select(x => new sambit.BLL.Models.PostModel(x));
            return posts.ToList();
        }

        public IList<sambit.BLL.Models.PostModel> GetPosts(int month)
        {
            var posts = _repository.Get()
                .Where(x => x.PostDate.Month == (month))
                .Select(x => new sambit.BLL.Models.PostModel(x));
            return posts.ToList();
        }

        public sambit.BLL.Models.PostModel GetLastPost()
        {
            var post = _repository.Get().OrderByDescending(x => x.PostDate).FirstOrDefault();
            
            if (post != null)
                return new sambit.BLL.Models.PostModel(post);
            else
                return new sambit.BLL.Models.PostModel();
        }

        public BResult AddPost(string title, string text)
        {
            Post p = new Post()
            {
                PostDate = DateTime.Now,
                Title = title.Trim(),
                Text = text.Trim()
            };

            _result.EntityId = _repository.Save(p);
            return _result;
        }
    }
}
