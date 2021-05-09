using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<List<Publisher>> GetAll();
        IResult Add(Publisher publisher);
        IResult Update(Publisher publisher);
        IResult Delete(Publisher publisher);
    }
}
