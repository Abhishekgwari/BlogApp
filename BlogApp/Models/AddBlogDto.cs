﻿namespace BlogApp.Models
{
    public class AddBlogDto
    {
        public required string Title { get; set; } // Title is mandatory

        public required string Content { get; set; } // Content is mandatory

        public required string Author { get; set; } // Author is mandatory

        public string Image { get; set; } // Image is optional (nullable)

        public required DateTime BlogDate { get; set; } // Date when the blog is created or published
    }
}