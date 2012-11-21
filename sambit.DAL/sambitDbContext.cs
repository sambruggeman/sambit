using sambit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace sambit.DAL
{
    public class sambitDbContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        public sambitDbContext()
            : base("sambitDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
