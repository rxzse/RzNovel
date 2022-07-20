using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class UserRegisterRespDto
    {
        [Display(Name="UserId")]
        public long id { get; set; }

        [Display(Name = "Token")]
        public string token { get; set; }
    }
}
