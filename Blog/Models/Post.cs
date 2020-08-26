using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Body { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public int Views { get; set; }
        public string PostImg { get; set; }
        public int BlogId { get; set; }
        public int Theme { get; set; }
        public bool CommentsAllowed { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}