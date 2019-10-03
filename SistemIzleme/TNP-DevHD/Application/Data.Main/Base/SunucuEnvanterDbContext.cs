using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Main.Models.Mapping;
using Rota2.DataCore;
using Domain.Main;
using Domain.Main.Models;
using Rota2.CrossCutting.Logging;
using Domain.Main.Envanter;
using Data.Main.Mapping.Envanter;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Main.Models
{
    public partial class SunucuEnvanterDbContext : REfUnitOfWork
    {
        public SunucuEnvanterDbContext(IEntityLogger entityLogger)
            : base(entityLogger)
        {
        }

        public DbSet<AvKullanici> AvKullanici { get; set; }
        public DbSet<AvServer> AvServer { get; set; }
        public DbSet<AvServerTipi> AvServerTipi { get; set; }
        public DbSet<AvLokasyon> AvLokasyon { get; set; }
        public DbSet<AvOperatingSystem> AvOperatingSystem { get; set; }
        public DbSet<AvYonetici> AvYonetici { get; set; }
        public DbSet<AvYoneticiServer> AvYoneticiServer { get; set; }

        public DbSet<AV_IISBINDING> AvSiteNames { get; set; }
        public DbSet<AvServerIliskiliSunucu> AvServerIliskiliSunucu { get; set; }
        public DbSet<AvServerUygulamalar> AvServerUygulamalar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new AvKullaniciMap());
            modelBuilder.Configurations.Add(new AvServerMap());
            modelBuilder.Configurations.Add(new AvServerTipiMap());
            modelBuilder.Configurations.Add(new AvLokasyonMap());
            modelBuilder.Configurations.Add(new AvOperatingSystemMap());
            modelBuilder.Configurations.Add(new AvYoneticiMap());
            modelBuilder.Configurations.Add(new AvYoneticiServerMap());
            modelBuilder.Configurations.Add(new AvServerIliskiliSunucuMap());
            modelBuilder.Configurations.Add(new AvServerUygulamalarMap());
        }
    }
}