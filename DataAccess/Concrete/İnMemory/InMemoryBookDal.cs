using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.İnMemory
{
    public class InMemoryBookDal : IBookDal
    {
        private List<Book> _books;

        public InMemoryBookDal()
        {
            _books = new List<Book>
            {
                new Book{BookId = 1, CategoryId = 1, KindName = "roman",  BookName = "Serseri", Author = "Aytaç Uzman", Publisher = "Can", YearOfPrinting = "2020", Description = "Roman"},
                new Book{BookId = 2, CategoryId = 1, KindName = "şiir",  BookName = "Günlük", Author = "Halil Mutlu", Publisher = "Etkin", YearOfPrinting = "2018", Description = "Roman"},
                new Book{BookId = 3, CategoryId = 2, KindName = "şiir",  BookName = "Yağmur", Author = "Eyüp Halid", Publisher = "Kapa", YearOfPrinting = "2015", Description = "Hikaye"},
                new Book{BookId = 4, CategoryId = 2, KindName = "tarih",  BookName = "Güz Güneşi", Author = "Sinan Uçar", Publisher = "Can", YearOfPrinting = "2018", Description = "Hikaye"},
                new Book{BookId = 5, CategoryId = 3, KindName = "tarih",  BookName = "Yakın Tarih", Author = "Mehmet Selim", Publisher = "ithaki", YearOfPrinting = "2019", Description = "Tarih"}
            };
        }
        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Delete(Book book)
        {
            Book bookToDelete = _books.SingleOrDefault(b => b.BookId == book.BookId);
            _books.Remove(bookToDelete);
        }

        public Book Get(Expression<Func<Book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllByCategory(int categoryId)
        {
            return _books.Where(b => b.CategoryId == categoryId).ToList();
        }

        public List<BookDetailDto> GetBookDetails()
        {
            throw new NotImplementedException();
        }

        public List<BookDetailDto> GetBookDetails(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            Book bookToUpdate = _books.SingleOrDefault(b => b.BookId == book.BookId);
            bookToUpdate.BookId = book.BookId;
            bookToUpdate.CategoryId = book.CategoryId;
            bookToUpdate.BookName = book.BookName;
            bookToUpdate.KindName = book.KindName;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Publisher = book.Publisher;
            bookToUpdate.YearOfPrinting = book.YearOfPrinting;
            bookToUpdate.Description = book.Description;
        }
    }
}
