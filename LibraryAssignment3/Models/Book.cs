﻿using System.ComponentModel.DataAnnotations;

namespace LibraryAssignment3.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
    }
}
