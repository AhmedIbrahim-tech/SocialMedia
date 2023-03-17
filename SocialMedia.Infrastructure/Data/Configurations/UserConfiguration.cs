namespace SocialMedia.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(30)
            .IsUnicode(false);

        builder.Property(e => e.DateOfBirth)
            .HasColumnType("date");

        builder.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsUnicode(false);
    }
}
