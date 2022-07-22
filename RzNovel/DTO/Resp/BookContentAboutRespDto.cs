using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookContentAboutRespDto
    {
        [Display(Name = "BookInfo")]
        public BookInfoRespDto bookInfo { get; set; }

        [Display(Name = "BookChapter")]
        public BookChapterRespDto chapterInfo { get; set; }

        [Display(Name = "ChapterContent")]
        public string content { get; set; }
    }
}
