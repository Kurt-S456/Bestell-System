using System;

namespace OrderSystem.Models
{
    public class ProOrd
    {
        public Guid ProId { get; set; }
        public ProProduct? Product { get; set; }
        public Guid OrdId { get; set; }
        public OrdOrder? Order { get; set; }
        public int count
        {
            get; set;

        }
    }
}