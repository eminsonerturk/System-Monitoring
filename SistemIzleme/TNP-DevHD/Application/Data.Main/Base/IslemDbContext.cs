using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Main.Models.Mapping;
using Rota2.DataCore;
using Domain.Main;
using Domain.Main.Models;
using Rota2.CrossCutting.Logging;
using System.Diagnostics;

namespace Data.Main.Models
{
    public partial class IslemDbContext : REfUnitOfWork
    {
        static IslemDbContext()
        {
            Database.SetInitializer<IslemDbContext>(null);
        }

        public IslemDbContext(IEntityLogger entityLogger)
            : base(entityLogger)
        {
        }

        public DbSet<IslemLog> IslemLog { get; set; }
        public DbSet<EntityFieldName> EntityFieldName { get; set; }
        public DbSet<EntityName> EntityName { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<EntityFieldLog> EntityFieldLog { get; set; }
        public DbSet<EntityLog> EntityLog { get; set; }
        public DbSet<MessageLog> MessageLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IslemLogMap());
            modelBuilder.Configurations.Add(new EntityFieldNameMap());
            modelBuilder.Configurations.Add(new EntityNameMap());
            modelBuilder.Configurations.Add(new KullaniciMap());
            modelBuilder.Configurations.Add(new EntityFieldLogMap());
            modelBuilder.Configurations.Add(new EntityLogMap());
            modelBuilder.Configurations.Add(new MessageLogMap());

            #if DEBUG
            Database.Log = s => Debug.Write(s);
            #endif

        }
        public void ChangeConnection(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
    }
}

