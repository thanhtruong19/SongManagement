using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SongManagementApp.Model;

public class SongDbContext : DbContext
{
    // phím tắt: DbSet tương ứng table
    public DbSet<Song> Songs { get; set; }

    public SongDbContext() { }
    public SongDbContext(DbContextOptions<SongDbContext> options): base(options) 
    { 

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Thay YOUR_SERVER, YOUR_DB, credentials cho phù hợp
        var conn = "Server=(localdb)\\MSSQLLocalDB;Database=SongDb;Trusted_Connection=True;";
        options.UseSqlServer(conn);
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        // nếu cần bổ sung cấu hình fluent API
        base.OnModelCreating(model);
    }
}
