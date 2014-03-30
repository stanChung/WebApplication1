using Microsoft.AspNet.SignalR;

namespace WebApplication1
{
    public interface IUserIdProvider
    {
        string GetUserId(IRequest request);
    }
}
