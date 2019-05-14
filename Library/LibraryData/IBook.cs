using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBook
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);

        void Add(Book book);
        void Edit(Book book);
        void Remove(int id);

        string GetTitle(int id);
        string GetAuthor(int id);
        string GetDescription(int id);
        int GetYear(int id);
    }
}
