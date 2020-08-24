using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Blog
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Body { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public string BlogImg { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}