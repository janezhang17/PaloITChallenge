using Microsoft.EntityFrameworkCore;
using PaloITChallenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaloITChallenge.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public virtual DbSet<FullName> FullNames { get; set; }
    }
}
