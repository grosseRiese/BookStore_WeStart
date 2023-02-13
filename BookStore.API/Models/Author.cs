﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}