namespace RecipeWebsite.Interfaces
{
    public interface IEmailSenderInterface
    {
        Task SendEmailAsync(string Email, string Subject, string Message);
    }
}
