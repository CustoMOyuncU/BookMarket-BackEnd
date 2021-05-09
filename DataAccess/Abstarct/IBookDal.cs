using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface IBookDal:IEntityRepository<Book>
    {
        List<BookDetailDto> GetBookDetailsDto();
    }
}
