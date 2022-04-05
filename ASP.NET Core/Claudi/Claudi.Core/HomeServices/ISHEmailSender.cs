namespace Claudi.Core.HomeServices
{
    using ViewModels.ContactsViewModel;

    public interface ISHEmailSender
    {
        Task Send(EmailContactViewModel model);
    }
}
