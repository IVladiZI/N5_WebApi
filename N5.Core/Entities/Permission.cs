using System;

namespace N5.Core.Entities
{
    public class Permission
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TypePermission { get; set; }
        public DateTime Date { get; set; }
    }
}
