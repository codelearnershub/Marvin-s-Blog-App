namespace MarvinBlogv._2._0.Models
{
    public class Review : BaseEntity
    { 
        public int Reaction { get; set; }
        public Post PostId { get; set; }
        public string Comment { get; set; }
    }
}
