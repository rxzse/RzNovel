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

        public Task<RestResp<string>> updateBook(BookAddReqDto dto, long userId);

        public Task<RestResp<string>> saveBookChapter(ChapterAddReqDto dto, long userId);
        public RestResp<List<BookCategoryRespDto>> listBookCategories();
        public Task<RestResp<PageRespDto<BookInfoRespDto>>> listAuthorBooks(PageReqDto dto, long userId);

        public Task<RestResp<BookInfoRespDto>> getBookById(long bookId);
    }
}
