using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookImageDetailDto:IDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
