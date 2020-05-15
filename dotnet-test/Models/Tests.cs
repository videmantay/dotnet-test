using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Tests
    {
        public Tests()
        {
            Participants = new HashSet<Participants>();
            TestingBlock = new HashSet<TestingBlock>();
        }

        public int TestId { get; set; }
        public DateTime TestDate { get; set; }
        public int CraftSerialNum { get; set; }

        public virtual Crafts CraftSerialNumNavigation { get; set; }
        public virtual ICollection<Participants> Participants { get; set; }
        public virtual ICollection<TestingBlock> TestingBlock { get; set; }
    }
}
