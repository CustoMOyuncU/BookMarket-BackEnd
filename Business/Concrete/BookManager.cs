using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult();
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<BookDetailDto>> GetBookDetailsDto()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetailsDto());
        }

        [CacheAspect]
        public IDataResult<List<BookDetailDto>> GetBooksDetailsByFilter(int writerId,int publisherId,int categoryId)
        {
            var result = CheckParametres(writerId, publisherId, categoryId);
            if (result != null)
            {
                return result;
            }
            return new SuccessDataResult<List<BookDetailDto>>(result.Data);
        }

        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult();
        }

        private IDataResult<List<BookDetailDto>> CheckParametres(int writerId,int publisherId,int categoryId)
        {
            if (writerId > 0 && publisherId > 0 && categoryId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.WriterId == writerId && b.PublisherId == publisherId && b.CategoryId == categoryId));
            }
            else if (writerId > 0 && publisherId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.WriterId == writerId && b.PublisherId == publisherId));
            }
            else if (categoryId > 0 && publisherId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.CategoryId == categoryId && b.PublisherId == publisherId));
            }
            else if (categoryId > 0 && writerId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.CategoryId == categoryId && b.WriterId == writerId));
            }
            else if (publisherId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.PublisherId == publisherId));
            }
            else if (categoryId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.CategoryId == categoryId));      
            }
            else if (writerId > 0)
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBooksByFilter(b => b.WriterId == writerId));          
            }
            return new ErrorDataResult<List<BookDetailDto>>(Messages.ParametersNotFound);
        }
    }
}