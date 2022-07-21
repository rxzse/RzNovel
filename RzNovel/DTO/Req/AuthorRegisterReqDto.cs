using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class AuthorRegisterReqDto
    {
        [Required(ErrorMessage = "userId must be cant empty")]
        [Display(Name = "userId")]
        public long userId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PenName must be cant empty"), MaxLength(20)]
        [Display(Name = "penName")]
        public string penName { get; set; }
    }
}
