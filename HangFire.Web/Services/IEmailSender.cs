using System.Threading.Tasks;

namespace HangFire.Web.Services
{
    internal interface IEmailSender
    {
        Task Sender(string userId, string message);
    }
}