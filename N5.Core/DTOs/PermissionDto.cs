using System;

namespace N5.Core.DTOs
{
    public class PermissionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long IdTypePermission { get; set; }
    }
    public class PermissionFindDto
    {
        public string Name { get; set; }
        public long? IdTypePermission { get; set; }
    }
}
