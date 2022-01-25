using Restaurant.Services.Email.Messages;

namespace Restaurant.Services.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
