using System;
using System.Collections.Generic;

namespace Ksiazki
{
    public interface ViewInterface
    {
        void UpdateItem(Book book);
        void UpdateListView(List<Book> items);
        void AddBookToListView(Book book);
        void DeleteBook(Book book);
    }
}


