using Claudi.Core.ViewModels.ContactsViewModel;

namespace Claudi.Core.HomeServices
{
    public interface ISHEmailSender
    {
        Task Send(EmailContactViewModel model);
    }
}
