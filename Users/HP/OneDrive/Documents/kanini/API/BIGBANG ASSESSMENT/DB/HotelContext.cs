using BIGBANG_ASSESSMENT.Models;
using Microsoft.EntityFrameworkCore;
using ClassLibrary3.Models;

namespace BIGBANG_ASSESSMENT.DB
{
    public class HotelContext: DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking>? Booking { get; set; }

       
    }
}
