using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzNovel.Models;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Services
{
    public interface IBookService
    {
        public Task<RestResp<string>> saveBook(BookAddReqDto dto, long userId);
        public Task<RestResp<bool>> saveBookChapter(ChapterAddReqDto dto);

        public Task<RestResp<List<BookCategoryRespDto>>> listBookCategories();
    }
}
