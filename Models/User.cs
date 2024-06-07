using System.ComponentModel.DataAnnotations;

namespace MakaleProject.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MailAddress is required")]
        public string MailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool State { get; set; }
        public int RoleId { get; set; }
        //TODO İLİŞKİLER
        public Role? Role { get; set; }
        public ICollection<ArticleDetails>? ArticleDetails { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
