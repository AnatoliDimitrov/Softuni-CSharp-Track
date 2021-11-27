using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    class ImportGameJsonDto
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}
