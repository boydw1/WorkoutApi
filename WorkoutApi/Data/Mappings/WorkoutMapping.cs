using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutApi.Data.Entities;

namespace WorkoutApi.Data.Mappings
{
    public class WorkoutMapping : IEntityTypeConfiguration<WorkoutEntity>
    {
        //Configure mappings for entities 
        public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
        {
            builder.ToTable("Workouts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
            builder.Property(x => x.Title).HasMaxLength(75);
        }
    }
}
