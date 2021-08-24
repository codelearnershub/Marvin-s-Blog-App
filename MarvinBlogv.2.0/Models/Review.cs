namespace MarvinBlogv._2._0.Models
{
    public class Review : BaseEntity
    { 
        public User User { get; set; }
        public int UserId { get; set; }
        public int CreatedById { get; set; }
        public int? Reaction { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}
