using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserInfo
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string NickName { get; set; }
        public string UserPhoto { get; set; }
        public byte? UserSex { get; set; }
        public long AccountBalance { get; set; }
        public byte Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
