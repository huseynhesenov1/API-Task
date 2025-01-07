using HospitalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HospitalProject.DAL.Configrations
{
    public class PatientConfigrations:IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
        }
    }
}
