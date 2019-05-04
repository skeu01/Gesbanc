
using System;
using System.ComponentModel.DataAnnotations;

namespace Gesbanc.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
