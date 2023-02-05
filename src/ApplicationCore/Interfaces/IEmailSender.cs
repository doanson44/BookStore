using System.Threading.Tasks;

namespace Microsoft.BookStore.ApplicationCore.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
