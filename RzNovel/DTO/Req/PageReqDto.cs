using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class PageReqDto
    {
        [Required]
        public int pageNum { get; set; } = 1;

        [Required]
        public int pageSize { get; set; } = 10;

        public bool fetchAll { get; set; } = false;

    }
}
