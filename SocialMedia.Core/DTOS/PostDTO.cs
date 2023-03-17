
namespace SocialMedia.Core.DTOS;

public class PostDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    //[Required]
    public string Description { get; set; }
    public string Image { get; set; }

    public int UserId { get; set; }
}
