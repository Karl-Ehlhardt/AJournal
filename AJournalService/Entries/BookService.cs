using AJournalData.Entries;
using AJournalModel.Entries.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AJournalData.User;
using System.Web.Http;

namespace AJournalService.Entries
{
    public class BookService
    {

        //private user field
        //private readonly Guid _userId;

        //private context
        private ApplicationDbContext _context = new ApplicationDbContext();

        //service constructor
        //public BookService(Guid userId)
        //{
        //    _userId = userId;
        //}

        //public async Task<bool> CheckOwner()
        //{

        //    Owner owner =
        //        await
        //        _context
        //        .Owners
        //        .SingleOrDefaultAsync(a => a.ApplicationUserId == _userId.ToString());

        //    return owner == null;
        //}

        //Create new Book
        public async Task<bool> CreateBook(BookCreate model)
        {
            Book Book =
                new Book()
                {
                    BookName = model.BookName,
                    Author = model.Author,
                    Rating = model.Rating,
                    NumberOfTimesRead = 1,
                    LastTimeRead = model.LastTimeRead,
                    PersonalSummary = model.PersonalSummary
                };

            _context.Books.Add(Book);
            return await _context.SaveChangesAsync() == 1;
        }

        //Get Book by id
        public async Task<BookDetails> GetBookById([FromUri] int id)
        {
            var query =
                await
                _context
                .Books
                .Where(q => q.BookId == id)
                .Select(
                    q =>
                    new BookDetails()
                    {
                        BookName = q.BookName,
                        Author = q.Author,
                        Rating = q.Rating,
                        NumberOfTimesRead = q.NumberOfTimesRead,
                        LastTimeRead = q.LastTimeRead,
                        PersonalSummary = q.PersonalSummary
                    }).ToListAsync();
            return query[0];
        }

        //Get Book by id Editable
        public async Task<BookEdit> GetBookByIdEditable([FromUri] int id)
        {
            var query =
                await
                _context
                .Books
                .Where(q => q.BookId == id)
                .Select(
                    q =>
                    new BookEdit()
                    {
                        BookName = q.BookName,
                        Author = q.Author,
                        Rating = q.Rating,
                        NumberOfTimesRead = q.NumberOfTimesRead,
                        LastTimeRead = q.LastTimeRead,
                        PersonalSummary = q.PersonalSummary
                    }).ToListAsync();
            return query[0];
        }

        //Update Book by id
        public async Task<bool> UpdateBook([FromUri] int id, [FromBody] BookEdit model)
        {
            Book Book =
                _context
                .Books
                .Single(a => a.BookId == id);
            Book.BookName = model.BookName;
            Book.Author = model.Author;
            Book.Rating = model.Rating;
            Book.NumberOfTimesRead = model.NumberOfTimesRead;
            Book.LastTimeRead = model.LastTimeRead;
            Book.PersonalSummary = model.PersonalSummary;

            return await _context.SaveChangesAsync() == 1;
        }

        //Get Book by id for Reread
        public async Task<BookReread> GetBookByIdReread([FromUri] int id)
        {
            var query =
                await
                _context
                .Books
                .Where(q => q.BookId == id)
                .Select(
                    q =>
                    new BookReread()
                    {
                        BookName = q.BookName,
                        Author = q.Author,
                        Rating = q.Rating,
                        LastTimeRead = q.LastTimeRead,
                        PersonalSummary = q.PersonalSummary
                    }).ToListAsync();
            return query[0];
        }


        //Reread Book by id
        public async Task<bool> RereadBook([FromUri] int id, [FromBody] BookReread model)
        {
            Book Book =
                _context
                .Books
                .Single(a => a.BookId == id);
            Book.Rating = model.Rating;
            Book.NumberOfTimesRead += 1;
            Book.LastTimeRead = model.LastTimeRead;
            Book.PersonalSummary = model.PersonalSummary;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
