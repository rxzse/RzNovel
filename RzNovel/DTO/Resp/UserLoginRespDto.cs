using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class UserLoginRespDto
    {
        [Display(Name="UserId")]
        public long id { get; set; }

        [Display(Name = "nickName")]
        public string nickName { get; set; }

        [Display(Name = "isAdmin")]
        public bool isAdmin { get; set; }
    }
}
