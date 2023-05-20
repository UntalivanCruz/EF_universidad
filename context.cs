using Microsoft.EntityFrameworkCore;
using universidades.Models;

namespace universidades
{
    public class context:DbContext
    {
        public DbSet<country> country {get;set;}

        public context(DbContextOptions<context> options) : base(options){}
    }
}