using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstarct
{
    public interface IBookImageDal:IEntityRepository<BookImage>
    {
        List<BookImageDetailDto> GetBookImageDetails();
    }
}
