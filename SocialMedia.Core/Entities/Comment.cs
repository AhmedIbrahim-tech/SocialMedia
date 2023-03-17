using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Entities;

public partial class Comment : BaseEntity
{
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }

    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}
