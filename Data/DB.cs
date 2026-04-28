using FinalsBL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalsBL.Data;

public class DB : DbContext
{
    public DB(DbContextOptions<DB> options) : base(options) { }

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<HobbyItem> HobbyItems => Set<HobbyItem>();
}