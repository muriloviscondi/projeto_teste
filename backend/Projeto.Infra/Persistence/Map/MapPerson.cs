using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Projeto.Infra.Persistence.Map
{
    public class MapPerson : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(450).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
