using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookInfoRespDto
    {
        [Display(Name = "Id")]
        public long id { get; set; }

        [Display(Name = "CategoryId")]
        public long categoryId { get; set; }

        [Display(Name = "CategoryName")]
        public string categoryName { get; set; }

        [Display(Name = "PicUrl")]
        public string picUrl { get; set; }

        [Display(Name = "BookName")]
        public string bookName { get; set; }

        [Display(Name = "AuthorId")]
        public long authorId { get; set; }

        [Display(Name = "AuthorName")]
        public string authorName { get; set; }

        [Display(Name = "BookDesc")]
        public string bookDesc { get; set; }

        [Display(Name = "BookStatus")]
        public byte bookStatus { get; set; }

        [Display(Name = "VisitCount")]
        public long visitCount { get; set; }

        [Display(Name = "WordCount")]
        public long wordCount { get; set; }

        [Display(Name = "CommentCount")]
        public long commentCount { get; set; }

        [Display(Name = "FirstChapterId")]
        public long firstChapterId { get; set; }

        [Display(Name = "LastChapterId")]
        public long lastChapterId { get; set; }

        [Display(Name = "LastChapterName")]
        public string lastChapterName { get; set; }

        [Display(Name = "UpdateTime")]
        public DateTime updateTime { get; set; }
    }
}
