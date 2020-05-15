using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class UsersHasRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
