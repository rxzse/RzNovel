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
    public interface IAuthorService
    {
        public Task<RestResp<string>> Register(AuthorRegisterReqDto dto);

        public Task<RestResp<string>> GetStatus(long userId);
    }
}
