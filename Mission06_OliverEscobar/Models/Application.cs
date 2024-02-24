using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mission06_OliverEscobar.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; } 
        public Category? CategoryName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required]
        public bool? CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
