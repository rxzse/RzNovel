using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookRankRespDto
    {
        [Display(Name = "Id")]
        public long id { get; set; }

        [Display(Name = "categoryId")]
        public long categoryId { get; set; }

        [Display(Name = "categoryName")]
        public string categoryName { get; set; }

        [Display(Name = "bookName")]
        public string bookName { get; set; }

        [Display(Name = "authorName")]
        public string authorName { get; set; }

        [Display(Name = "bookDesc")]
        public string bookDesc { get; set; }

        [Display(Name = "wordCount")]
        public int wordCount { get; set; }

        [Display(Name = "lastChapterName")]
        public string lastChapterName { get; set; }

        [Display(Name = "lastChapterUpdateTime")]
        public DateTime lastChapterUpdateTime { get; set; }
    }
}
