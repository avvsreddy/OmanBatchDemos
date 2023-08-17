using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebApp.Models
{
    public class ArticleSubmitViewModel
    {
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
    }
}
