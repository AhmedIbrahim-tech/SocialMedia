namespace SocialMedia.Infrastructure.Data.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

        builder.Property(e => e.Date)
            .HasColumnName("Date")
            .HasColumnType("datetime");

        builder.Property(e => e.Image)
            .HasColumnName("Image")
            .HasMaxLength(500)
            .IsUnicode(false);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Posts)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Post_User");
    }
}
