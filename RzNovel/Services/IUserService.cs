using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;

namespace RzNovel.Services
{
    public interface IUserService
    {
        public Task<ActionResult<UserRegisterRespDto>> Register(UserRegisterReqDto dto);
    }
}
