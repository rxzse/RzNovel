using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class UserRegisterReqDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username must be cant empty"), MaxLength(15)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be cant empty"), MaxLength(20)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
