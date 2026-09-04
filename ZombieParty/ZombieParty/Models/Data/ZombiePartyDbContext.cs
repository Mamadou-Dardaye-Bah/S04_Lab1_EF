namespace ZombieParty.Models.Data;

using Microsoft.EntityFrameworkCore;

public class ZombiePartyDbContext : DbContext
{
    public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
    {

    }
    public DbSet<Zombie> zombies { get; set; }
    public DbSet<ZombieType> zombieTypes { get; set; }

}
