using System;

namespace SeniorDating.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Private { get; set; }
        public ApplicationUser From { get; set; }
        public ApplicationUser To { get; set; }
       
    }
}