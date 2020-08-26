using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(512)]
        public string Body { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Post Post { get; set; }
    }
}