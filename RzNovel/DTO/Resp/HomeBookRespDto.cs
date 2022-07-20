using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class HomeBookRespDto
    {
        [Display(Name = "Type")]
        public byte type { get; set; }

        [Display(Name = "BookId")]
        public long bookId { get; set; }

        [Display(Name = "PictureUrl")]
        public string picUrl { get; set; }

        [Display(Name = "BookName")]
        public string bookName { get; set; }

        [Display(Name = "AuthorName")]
        public string authorName { get; set; }

        [Display(Name = "BookDesc")]
        public string bookDesc { get; set; }
    }
}
