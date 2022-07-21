using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Services
{
    public interface IUserService
    {
        public Task<RestResp<UserRegisterRespDto>> Register(UserRegisterReqDto dto);

        public Task<RestResp<UserLoginRespDto>> Login(UserLoginReqDto dto);
    }
}
