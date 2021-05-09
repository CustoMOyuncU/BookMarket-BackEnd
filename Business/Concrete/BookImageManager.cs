using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        IBookImageDal _bookImageDal;

        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }

        public IResult Add(IFormFile file, BookImage bookImage)
        {
            bookImage.ImagePath = FileHelper.Add(file);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Add(bookImage);
            return new SuccessResult();
        }

        public IResult Delete(BookImage bookImage)
        {
            _bookImageDal.Delete(bookImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<List<BookImageDetailDto>> GetBookImageDetails()
        {
            return new SuccessDataResult<List<BookImageDetailDto>>(_bookImageDal.GetBookImageDetails());
        }

        public IDataResult<List<BookImageDetailDto>> GetByBookId(int id)
        {
            var data = _bookImageDal.GetBookImageDetails();
            return new SuccessDataResult<List<BookImageDetailDto>>(data.FindAll(i => i.BookId == id));
        }

        public IDataResult<BookImage> GetById(int id)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(i => i.Id == id));
        }

        public IResult Update(BookImage bookImage)
        {
            _bookImageDal.Update(bookImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
