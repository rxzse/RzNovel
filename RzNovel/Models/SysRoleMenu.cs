using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class SysRoleMenu
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long MenuId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
