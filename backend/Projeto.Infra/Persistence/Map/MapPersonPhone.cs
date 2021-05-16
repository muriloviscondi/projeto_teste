using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Projeto.Infra.Persistence.Map
{
    public class MapPersonPhone : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(450).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhoneNumberTypeID).HasMaxLength(450).IsRequired();

            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.PersonId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PhoneNumberType).WithMany().HasForeignKey(p => p.PhoneNumberTypeID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
