using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        [Url(ErrorMessage = "Provide valid url")]
        public string URL { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        //[ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public bool IsApproved { get; set; }
        [Required]
        public string PostedBy { get; set; }

        public DateTime DateSubmited { get; set; }
    }
}
