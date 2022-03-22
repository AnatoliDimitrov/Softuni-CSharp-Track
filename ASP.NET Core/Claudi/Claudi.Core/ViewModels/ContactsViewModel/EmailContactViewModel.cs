namespace Claudi.Core.ViewModels.ContactsViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class EmailContactViewModel
    {

        [Required]
        [EmailAddress(ErrorMessage ="Въведете валиден имейл адрес.")]
        public string From { get; set; } = "info@cludi.bg";

        public string To { get; set; } = "info@cludi.bg";
 

         [Required]
        [MaxLength(50, ErrorMessage ="Не повече от 50 символа.")]
        [MinLength(3, ErrorMessage ="Не по малко от 3 символа.")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Не повече от 1000 символа.")]
        [MinLength(3, ErrorMessage = "Не по малко от 5 символа.")]
        public string Message { get; set; }
    }
}
