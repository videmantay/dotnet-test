using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Participants
    {
        public int TestId { get; set; }
        public int CraftSerialNum { get; set; }
        public int UserId { get; set; }
        public string Duty { get; set; }
        public string Quals { get; set; }

        public virtual Tests Tests { get; set; }
        public virtual Users User { get; set; }
    }
}
