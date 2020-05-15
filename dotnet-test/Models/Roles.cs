using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UsersHasRoles = new HashSet<UsersHasRoles>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersHasRoles> UsersHasRoles { get; set; }
    }
}
