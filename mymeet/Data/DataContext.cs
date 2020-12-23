
using Microsoft.EntityFrameworkCore;
using mymeet.Models;

namespace mymeet.Data
{
  public class DataContextAplication : DbContext
  {

    public DataContextAplication(DbContextOptions<DataContextAplication> options)
    : base(options)
    {

    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Meeting> Meetings { get; set; }



  }
}