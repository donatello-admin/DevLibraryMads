﻿namespace DevLibraryMads.Core.DTOs
{
    public class BookDTOs
    {
        public BookDTOs(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
