using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class BookSearchReqDto: PageReqDto
    {
        
        [Display(Name = "keyword")]
        public string keyword { get; set; }


        [Display(Name = "category")]
        public long category { get; set; } = 0;

        [Display(Name = "categoryName")]
        public string categoryName { get; set; }

        [Display(Name = "status")]
        public int status { get; set; }

        [Display(Name = "sortField")]
        public string sort { get; set; }
    }
}
