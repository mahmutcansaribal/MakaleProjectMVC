using System.ComponentModel.DataAnnotations;

namespace MakaleProject.Models
{
    public class ArticleDetails
    {
        [Key]
        public int MakeleID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ArContent { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
