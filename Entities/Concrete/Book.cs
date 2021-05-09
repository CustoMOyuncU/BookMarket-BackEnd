using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public string BookName { get; set; }
        public DateTime WritedDate { get; set; }
    }
}
