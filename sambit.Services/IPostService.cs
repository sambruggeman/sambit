using sambit.BLL.Lib;
using sambit.BLL.Base;
using sambit.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sambit.BLL
{
    public interface IPostService: IEntityBase
    {
        sambit.BLL.Models.PostModel GetPost(int id);
        IList<sambit.BLL.Models.PostModel> GetPosts();
        IList<sambit.BLL.Models.PostModel> GetPosts(int month);
        sambit.BLL.Models.PostModel GetLastPost();

        BResult AddPost(string title, string text);
    }
}
