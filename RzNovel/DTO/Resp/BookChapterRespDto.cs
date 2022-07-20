using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookChapterRespDto
    {
        [Display(Name = "Id")]
        public long id { get; set; }

        [Display(Name = "BookId")]
        public long bookId { get; set; }

        [Display(Name = "ChapterNum")]
        public int chapterNum { get; set; }

        [Display(Name = "ChapterName")]
        public string chapterName { get; set; }

        [Display(Name = "ChapterWordCount")]
        public long chapterWordCount { get; set; }

        [Display(Name = "ChapterUpdateTime")]
        public DateTime chapterUpdateTime { get; set; }
    }
}
