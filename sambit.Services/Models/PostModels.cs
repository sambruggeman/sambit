using sambit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sambit.BLL.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public PostModel()
        {

        }

        public PostModel(Post post)
        {
            this.Id = post.Id;
            this.PostDate = post.PostDate;
            this.Title = post.Title;
            this.Text = post.Text;
        }
    }
}
