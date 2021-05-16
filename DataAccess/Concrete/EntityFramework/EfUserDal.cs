using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstarct;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BooksContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new BooksContext())
            {
                var result = from o in context.OperationClaims
                             join u in context.UserOperationClaims
                                 on o.Id equals u.OperationClaimId
                             where u.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = o.Id,
                                 Name = o.Name
                             };
                return result.ToList();
            }
        }
    }
}
