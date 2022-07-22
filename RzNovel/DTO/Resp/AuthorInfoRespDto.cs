using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Resp
{
    public class AuthorInfoRespDto
    {
        [Display(Name = "authorId")]
        public long authorId { get; set; }

        [Display(Name = "penName")]
        public string penName { get; set; }

        [Display(Name = "userId")]
        public long userId { get; set; }

        [Display(Name = "userName")]
        public string userName { get; set; }

        [Display(Name = "status")]
        public int status { get; set; }

        [Display(Name = "createTime")]
        public DateTime createTime { get; set; }

        [Display(Name = "updateTime")]
        public DateTime updateTime { get; set; }
    }
}
