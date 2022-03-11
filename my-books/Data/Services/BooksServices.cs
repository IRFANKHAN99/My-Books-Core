
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksServices
    {
        private AppDbcontext _context;
        public BooksServices(AppDbcontext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

        }

        public List<Book> GetAllBook()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        public Book GetBookById (int Id)
        {
            var BookData = _context.Books.FirstOrDefault(x => x.Id == Id);
            return BookData;
        }

        public void Delete(int Id)
        {
            var DeletedObject = _context.Books.Find(Id);
            _context.Books.Remove(DeletedObject);
            _context.SaveChanges();
        }

        public Book UpdateBook(int Id, BookVM book)
        {
            var updatedBook = _context.Books.First(x => x.Id == Id);
            if (updatedBook != null)
            {
                updatedBook.Title = book.Title;
                updatedBook.Description = book.Description;
                updatedBook.Author = book.Author;
                updatedBook.CoverUrl = book.CoverUrl;
                updatedBook.DateAdded = DateTime.Now;
                _context.SaveChanges();
            }
            return updatedBook;

        }


    }
}
