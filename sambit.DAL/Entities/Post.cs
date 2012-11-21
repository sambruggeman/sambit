using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sambit.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace sambit.DAL.Entities
{
    public class Post: EntityBase
    {
        //public int Id { get; set; }
        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Username { get; set; }
    }
}
