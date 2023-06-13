using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Contexts;

public class EntityDbContext: DbContext
{
    public EntityDbContext(DbContextOptions<EntityDbContext> dbContextOptions) : base(dbContextOptions) 
    {
        
    }
    

    public DbSet<Person> Persons { get; set; }
}