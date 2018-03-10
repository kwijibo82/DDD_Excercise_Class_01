using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioContext : DbContext
    {
        public EnvioContext() : base("EnvioContext")
        {
            //Database.SetInitializer(new EnvioContextInitializer());
        }

        public DbSet<EnvioSnapShot> Envios { get; set; }
        public DbSet<EnvioPersonaSnapShot> Personas { get; set; }
        public DbSet<DireccionSnapShot> Direcciones { get; set; }
        public DbSet<BultoSnapShot> Bultos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}