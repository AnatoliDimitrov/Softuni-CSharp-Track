using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportBookJsonDto
    {
        [Required]
        public int? Id { get; set; }
    }
}
