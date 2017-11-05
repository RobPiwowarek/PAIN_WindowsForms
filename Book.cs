using System;

namespace Ksiazki
{
    public class Book
    {
        public String title { get; set; }
        public String author { get; set; }
        public String date { get; set; }
        public String category { get; set; }

        public Book(String title, String author, String date, String category)
        {
            this.title = title;
            this.author = author;
            this.date = date;
            this.category = category;
        }
    }
}
