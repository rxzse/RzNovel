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
    public interface IAdminService
    {
        public Task<RestResp<string>> updateAuthorStatus(AdminUpdAuthorDto dto);

        public Task<RestResp<string>> addCategory(AdminAddCategoryDto dto);

        public Task<RestResp<string>> updateCategory(AdminAddCategoryDto dto);

        public Task<RestResp<PageRespDto<AuthorInfoRespDto>>> listAuthors(PageReqDto dto);
    }
}
