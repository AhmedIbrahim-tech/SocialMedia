namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .WithMessage("Description cannot be null");

            RuleFor(post => post.Description)
                .Length(10, 500)
                .WithMessage("The length of the description must be between 10 and 500 characters");

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);

        }
    }
}
