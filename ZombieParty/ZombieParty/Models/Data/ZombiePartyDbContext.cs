namespace ZombieParty.Models.Data;

using Microsoft.EntityFrameworkCore;

public class ZombiePartyDbContext : DbContext
{
    public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
    {

    }

}
