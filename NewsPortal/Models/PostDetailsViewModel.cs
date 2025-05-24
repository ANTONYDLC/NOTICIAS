using System.Collections.Generic;

namespace NewsPortal.Models
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
