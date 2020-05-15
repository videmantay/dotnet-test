using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Users
    {
        public Users()
        {
            Participants = new HashSet<Participants>();
            UsersHasRoles = new HashSet<UsersHasRoles>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CallName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Participants> Participants { get; set; }
        public virtual ICollection<UsersHasRoles> UsersHasRoles { get; set; }
    }
}
