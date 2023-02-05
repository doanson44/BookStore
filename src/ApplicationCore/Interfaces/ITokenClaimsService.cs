using System.Threading.Tasks;

namespace Microsoft.BookStore.ApplicationCore.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}
