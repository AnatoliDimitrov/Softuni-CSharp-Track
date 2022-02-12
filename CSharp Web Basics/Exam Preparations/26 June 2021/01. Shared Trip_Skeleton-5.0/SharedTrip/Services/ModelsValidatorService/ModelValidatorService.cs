namespace SharedTrip.Services.ModelsValidatorService
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ModelValidatorService : IModelValidatorService
    {
        public ICollection<string> ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, errors, true);

            return errors
                .Select(e => e.ToString())
                .ToList();
        }
    }
}
