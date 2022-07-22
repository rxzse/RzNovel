using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookChapterAboutRespDto
    {
        [Display(Name = "BookChapter")]
        public BookChapterRespDto chapterInfo { get; set; }

        [Display(Name = "ChapterTotal")]
        public long chapterTotal { get; set; }

        [Display(Name = "ContentSummary")]
        public string contentSummary { get; set; }
    }
}
