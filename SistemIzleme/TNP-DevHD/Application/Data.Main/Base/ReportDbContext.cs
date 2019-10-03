using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Main.Models.Mapping;
using Rota2.DataCore;
using Domain.Main;
using Domain.Main.Models;
using Rota2.CrossCutting.Logging;

namespace Data.Main.Models
{
    public partial class ReportDbContext : REfUnitOfWork
    {
        static ReportDbContext()
        {
            Database.SetInitializer<ReportDbContext>(null);
        }

        public ReportDbContext(IEntityLogger entityLogger)
            : base(entityLogger)
        {
        }
       
        public DbSet<ReportServer> ReportServer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReportServerMap());
        }

        public void ChangeConnection(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
    }
}

