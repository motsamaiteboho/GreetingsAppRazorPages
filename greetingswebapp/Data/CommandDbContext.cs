using greetingswebapp.Models;
using Microsoft.EntityFrameworkCore;
public class CommandDbContext: DbContext
{
    public CommandDbContext(DbContextOptions options):base(options)
    {

    }

    public DbSet<CommandModel> Commands {get; set;}
}