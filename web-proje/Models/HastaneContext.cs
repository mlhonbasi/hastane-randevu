using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace web_proje.Models
{
    public class HastaneContext: DbContext
    {
        public DbSet<Hastane> Hastane { get; set; }
        public DbSet<Polikinlik> Polikinlikler { get; set; }
        
        public DbSet<Kullanici>Kullanicilar { get; set; }

        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        
        public HastaneContext(DbContextOptions<HastaneContext> options) : base(options)
        {

        }
    }
}
