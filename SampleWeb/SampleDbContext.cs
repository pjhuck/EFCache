using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleWeb
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {

        }
        public SampleDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}