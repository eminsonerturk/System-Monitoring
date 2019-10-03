using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Main.Models.Mapping;
using Rota2.DataCore;
using Domain.Main;
using Domain.Main.Models;
using Rota2.CrossCutting.Logging;

namespace Data.Main.Models
{
    public partial class ElmahDbContext : REfUnitOfWork
    {
        static ElmahDbContext()
        {
            Database.SetInitializer<ElmahDbContext>(null);
        }

        public ElmahDbContext(IEntityLogger entityLogger)
            : base(entityLogger)
        {
        }
       
        public DbSet<ElmahError> ElmahError { get; set; }
        public DbSet<ExceptionRequest> ExceptionRequest { get; set; }
        public DbSet<KullaniciApp> KullaniciApp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ElmahErrorMap());
            modelBuilder.Configurations.Add(new ExceptionRequestMap());
            modelBuilder.Configurations.Add(new KullaniciAppMap());
        }
    }
}