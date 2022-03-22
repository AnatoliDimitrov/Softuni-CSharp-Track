namespace Claudi.Core.ViewModels.ContactsViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class EmailContactViewModel
    {

        [Required]
        [EmailAddress(ErrorMessage ="Въведете валиден имейл адрес.")]
        public string From { get; set; }
 

         [Required]
        [MaxLength(50, ErrorMessage = "Заглавието не трябва да е повече от 50 символа.")]
        [MinLength(3, ErrorMessage = "Заглавието не трябва да е по малко от 3 символа.")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Съдържанието не трябва да е повече от 1000 символа.")]
        [MinLength(5, ErrorMessage = "Съдържанието не трябва да е по малко от 5 символа.")]
        public string Message { get; set; }
    }
}
