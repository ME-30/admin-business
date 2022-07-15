using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace WebApplication7.DAL.Database
{
    public class DbContainer : IdentityDbContext
    {

        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) {}
        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Mail> Mail { get; set; }


    }
}
