using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface IBookDal:IEntityRepository<Book>
    {
        List<BookDetailDto> GetBookDetailsDto();
        List<BookDetailDto> GetBooksByFilter(Expression<Func<BookDetailDto, bool>> filter = null);
    }
}
