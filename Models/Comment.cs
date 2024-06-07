namespace MakaleProject.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ArticleID { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
        public ArticleDetails ArticleDetails { get; set; }
    }
}
