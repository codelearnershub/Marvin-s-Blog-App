namespace MarvinBlogv._2._0.Models
{
    public class Review : BaseEntity
    { 
        public User MadeBy { get; set; }
        public int CreatedById { get; set; }
        public int Reaction { get; set; }
        public Post Post { get; set; }
        public string Comment { get; set; }
    }
}
