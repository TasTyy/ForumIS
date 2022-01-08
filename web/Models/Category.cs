using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}