using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class BookCategoryRespDto
    {
        [Display(Name = "Id")]
        public long id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
    }
}
