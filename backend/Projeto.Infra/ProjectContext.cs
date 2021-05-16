using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using Project.Domain.Entities;
using Projeto.Infra.Persistence.Map;

namespace Projeto.Infra
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
      : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonPhone> PersonPhones { get; set; }

        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Adiciona entidades mapeadas
            modelBuilder.ApplyConfiguration(new MapPerson());
            modelBuilder.ApplyConfiguration(new MapPersonPhone());
            modelBuilder.ApplyConfiguration(new MapPhoneNumberType());
            #endregion
        }
    }
}
