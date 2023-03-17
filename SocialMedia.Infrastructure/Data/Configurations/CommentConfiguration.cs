namespace SocialMedia.Infrastructure.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(e => e.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasMaxLength(500)
            .IsUnicode(false);

        builder.Property(e => e.Date).HasColumnName("Date").HasColumnType("datetime");


        builder.HasOne(d => d.Post)
           .WithMany(p => p.Comments)
           .HasForeignKey(d => d.PostId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Comment_Post");

        builder.HasOne(d => d.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Comment_User");
    }
}
