using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCR.Core.Model;

namespace OCR.DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Page> Page { get; set; }
        public DbSet<Account> Account { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
