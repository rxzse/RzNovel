using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class AdminAddCategoryDto
    {
        [Required]
        public long id { get; set; } = 0;
        [Required]
        public string name { get; set; }
        [Required]
        public byte sort { get; set; }
    }
}
