using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagment.Core.Entities;

namespace StoreManagment.DAL.Configrations;

public class AppUserConfigration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x=>x.LastName).HasMaxLength(20);
        builder.Property(x=>x.FirstName).HasMaxLength(20);
    }
}
