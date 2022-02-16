namespace Git.Services.ModelsValidatorService
{
    using System.Collections.Generic;

    public interface IModelValidatorService
    {
        ICollection<string> ValidateModel(object model);
    }
}
