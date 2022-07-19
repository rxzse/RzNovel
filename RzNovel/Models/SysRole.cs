using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class SysRole
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string RoleSign { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
