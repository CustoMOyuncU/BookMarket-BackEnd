using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using Entities.Concrete;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using DataAccess.Concrete.Contexts;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BooksContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetailsDto()
        {
            using (BooksContext context = new BooksContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryId equals c.Id
                             join p in context.Publishers
                             on b.PublisherId equals p.Id
                             join w in context.Writers
                             on b.WriterId equals w.Id
                             select new BookDetailDto
                             {
                                 BookId = b.Id,
                                 WriterId = w.Id,
                                 PublisherId = p.Id,
                                 CategoryId = c.Id,
                                 WriterName = w.WriterName,
                                 PublisherName = p.PublisherName,
                                 CategoryName = c.CategoryName,
                                 BookName = b.BookName,
                                 UnitPrice = b.UnitPrice
                             };
                return result.ToList();
            }
        }

        public List<BookDetailDto> GetBooksByFilter(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            using (BooksContext context = new BooksContext())
            {
                var result = from b in context.Books
                             join p in context.Publishers
                             on b.PublisherId equals p.Id
                             join w in context.Writers
                             on b.WriterId equals w.Id
                             join c in context.Categories
                             on b.CategoryId equals c.Id
                             select new BookDetailDto
                             {
                                 BookId = b.Id,
                                 PublisherId = p.Id,
                                 WriterId = w.Id,
                                 CategoryId = c.Id,
                                 PublisherName = p.PublisherName,
                                 BookName = b.BookName,
                                 WriterName = w.WriterName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = b.UnitPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
