﻿using DevLibraryMads.Core.Enums;

namespace DevLibraryMads.Core.Entities
{
    public class Book : EntityBase
    {
        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public List<Order> Orders { get; private set; }

        public void Update(string  title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }
    }
}
