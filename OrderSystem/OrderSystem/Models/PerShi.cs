namespace OrderSystem.Models
{
    public class PerShi
    {
        public Guid PerId { get; set; }
        public PerPerson? Person { get; set; }

        public Guid ShiId{ get; set; }
        public ShiShift? Shift { get; set; }

        public Guid RoleId { get; set; }
        public RoRole? Role { get; set; }
    }
}
