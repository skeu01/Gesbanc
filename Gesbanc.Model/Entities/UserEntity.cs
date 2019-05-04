using System;
using System.Collections.Generic;
using System.Text;

namespace Gesbanc.Model.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
