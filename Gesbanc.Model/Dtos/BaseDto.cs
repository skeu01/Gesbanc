using System;

namespace Gesbanc.Model.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
