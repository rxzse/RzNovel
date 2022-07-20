using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class BookAddReqDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryId must be cant empty")]
        [Display(Name = "CategoryId")]
        public long categoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CategoryName must be cant empty")]
        [Display(Name = "CategoryName")]
        public string categoryName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PicUrl must be cant empty")]
        [Display(Name = "PicUrl")]
        public string picUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "BookName must be cant empty")]
        [Display(Name = "BookName")]
        public string bookName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "BookDesc must be cant empty")]
        [Display(Name = "BookDesc")]
        public string bookDesc { get; set; }


    }
}
