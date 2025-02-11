using Calculator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Calculator.Data.CalculationDbContext
{
    public partial class CalcDbContext : DbContext
    {
        public CalcDbContext()
        {
            
        }
        public CalcDbContext(DbContextOptions<CalcDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalculationHistory> OperationHistory { get; set; }

        public virtual DbSet<Operations> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operations>(entity =>
            {
                //  entity.HasNoKey();
                entity.Property(c => c.Name);
                entity.Property(c => c.Description);
                entity.Property(c => c.ParameterAType);
                entity.Property(c => c.ParameterBType);

            });

            modelBuilder.Entity<CalculationHistory>(entity =>
            {
                entity.HasOne(d => d.Ooperation)
                                    .WithMany(p => p.CalculationHistories)
                                    .HasForeignKey(d => d.OperationId)
                                    .OnDelete(DeleteBehavior.Restrict);
                //entity.Property(c => c.Operation).IsRequired()
                //.HasMaxLength(50);
                entity.Property(c => c.FieldA).IsRequired().HasMaxLength(50);
                entity.Property(c => c.FieldB).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Result).HasMaxLength(50);
            });

      

        }
    }
}
