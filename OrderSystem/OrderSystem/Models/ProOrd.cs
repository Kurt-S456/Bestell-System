using System;

namespace OrderSystem.Models
{
    public class ProOrd
    {
        public Guid ProId { get; set; }
        public ProProduct Product { get; set; } = null!;
        public Guid OrdId { get; set; }
        public OrdOrder Order { get; set; } = null!;
        public int count
        {
            get; set;

        }
    }
}