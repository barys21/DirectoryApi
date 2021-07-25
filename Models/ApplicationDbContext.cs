using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryApi.Models;

namespace DirectoryApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<DirectoryOne> DirectoryOnes { get; set; }
        public DbSet<DirectoryTwo> DirectoryTwos { get; set; }
        public DbSet<DirectoryAPL> DirectoryAPLs { get; set; }
        public DbSet<DirectoryAplCommandPlayer> DirectoryAplCommandPlayers { get; set; }
    }
}
