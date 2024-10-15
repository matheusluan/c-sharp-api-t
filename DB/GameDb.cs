using c_sharp_api_t.Models;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_api_t.DB;

public class GameDb: DbContext
{
    public GameDb(DbContextOptions<GameDb> options)
        : base(options) { }

    public DbSet<Game> Games => Set<Game>();
}