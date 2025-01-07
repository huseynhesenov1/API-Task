using HospitalProject.Core.Entities;
using HospitalProject.DAL.Configrations;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.DAL.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt){}
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientConfigrations).Assembly);
        }
    }
}
 