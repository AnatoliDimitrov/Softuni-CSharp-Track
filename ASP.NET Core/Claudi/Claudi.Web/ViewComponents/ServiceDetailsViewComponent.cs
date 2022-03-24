namespace Claudi.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;

    using Core.CommonServices;

    [ViewComponent(Name = "ServiceDetails")]
    public class ServiceDetailsViewComponent : ViewComponent
    {
        private readonly ICommonService _service;

        public ServiceDetailsViewComponent(ICommonService service)
        {
            this._service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var types = await _service.GetAllTypesAsync();

            return this.View(types);

        }
    }
}
