using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookImageDal : EfEntityRepositoryBase<BookImage, BooksContext>, IBookImageDal
    {
        public List<BookImageDetailDto> GetBookImageDetails()
        {
            using (BooksContext context = new BooksContext())
            {
                var result = from i in context.BookImages
                             join b in context.Books
                             on i.BookId equals b.Id
                             select new BookImageDetailDto
                             {
                                 Id = i.Id,
                                 BookId = b.Id,
                                 ImagePath = i.ImagePath,
                                 Date = i.Date
                             };
                return result.ToList();
            }
        }
    }
}
