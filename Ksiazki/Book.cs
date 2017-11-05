using System;

namespace Ksiazki
{
    public class Book
    {
        public String title { get; set; }
        public String author { get; set; }
        public DateTime date { get; set; }
        public String category { get; set; }

        public Book(String title, String author, DateTime date, String category)
        {
            this.title = title;
            this.author = author;
            this.date = date;
            this.category = category;
        }
    }
}
