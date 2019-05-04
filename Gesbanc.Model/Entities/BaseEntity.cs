
using System;
using System.ComponentModel.DataAnnotations;

namespace Gesbanc.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get { return DateTime.Now; } }
        public DateTime DateUpdated { get { if (DateUpdated == null) { return DateTime.Now; } return DateUpdated; } }
    }
}
