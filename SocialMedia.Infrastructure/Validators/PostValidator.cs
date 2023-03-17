
namespace SocialMedia.Infrastructure.Validators;

public class PostValidator : AbstractValidator<PostDTO>
{
    public PostValidator()
    {
        RuleFor(post => post.Description)
            .NotNull()
            .WithMessage("Description can't be null")
            .Length(10, 500)
            .WithMessage("The length of the description must be between 10 and 500 characters");


        RuleFor(post => post.Date)
            .NotNull()
            .LessThan(DateTime.Now).WithMessage("The DateTime can't be Greater Than Date of Today ");

    }
}
