

namespace SocialMedia.Infrastructure.Data.Configurations;

public class SecurityConfiguration : IEntityTypeConfiguration<Security>
{
    public void Configure(EntityTypeBuilder<Security> builder)
    {
        builder.ToTable("Securities");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.User)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(200)
            .IsUnicode(false);

        builder.Property(e => e.Role)
           .HasMaxLength(15)
           .IsRequired()
           .HasConversion(
            x => x.ToString(),
            x => (RoleType)Enum.Parse(typeof(RoleType), x));

    }
}
