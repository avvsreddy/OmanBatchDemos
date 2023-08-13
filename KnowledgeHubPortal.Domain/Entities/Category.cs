using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
