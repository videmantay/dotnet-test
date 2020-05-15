using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class TestingBlock
    {
        public TestingBlock()
        {
            TestPoints = new HashSet<TestPoints>();
        }

        public int TestingBlockId { get; set; }
        public string Name { get; set; }
        public string Focus { get; set; }
        public int TestId { get; set; }
        public int TestCraftSerialNum { get; set; }

        public virtual Tests Test { get; set; }
        public virtual ICollection<TestPoints> TestPoints { get; set; }
    }
}
