using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Projeto.Infra.Persistence.Map
{
    public class MapPhoneNumberType : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(450).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
