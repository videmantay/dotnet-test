using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class TestPoints
    {
        public int TestPointId { get; set; }
        public string Description { get; set; }
        public decimal? Result { get; set; }
        public string Title { get; set; }
        public string Conditions { get; set; }
        public int TestingBlockId { get; set; }
        public int TestId { get; set; }
        public int TestCraftSerialNum { get; set; }

        public virtual TestingBlock Test { get; set; }
    }
}
