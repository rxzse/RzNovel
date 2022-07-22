using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class ChapterAddReqDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "BookId must be cant empty")]
        [Display(Name = "BookId")]
        public long bookId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ChapterName must be cant empty")]
        [Display(Name = "ChapterName")]
        public string chapterName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ChapterContent must be cant empty")]
        [Display(Name = "ChapterContent")]
        public string chapterContent { get; set; }

        public long chapterId { get; set; } = 0;
    }
}
