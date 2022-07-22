using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RzNovel.DTO.Req
{
    public class AdminUpdAuthorDto
    {
        [Required]
        public long authorId { get; set; }

        [Required]
        public byte status { get; set; }
    }
}
