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
        public RestResp<List<BookCategoryRespDto>> listBookCategories();
        public Task<RestResp<PageRespDto<BookInfoRespDto>>> listAuthorBooks(PageReqDto dto, long userId);
        public Task<RestResp<PageRespDto<BookChapterRespDto>>> listBookChapters(PageReqDto dto, long bookId);
        public Task<RestResp<List<BookChapterRespDto>>> listChapters(long bookId);
        public Task<RestResp<BookInfoRespDto>> getBookById(long bookId);
        public Task<RestResp<BookChapterAboutRespDto>> getLastChapterAbout(long bookId);
        public Task<RestResp<string>> saveBook(BookAddReqDto dto, long userId);
        public Task<RestResp<string>> updateBook(BookAddReqDto dto, long userId);
        public Task<RestResp<string>> saveBookChapter(ChapterAddReqDto dto, long userId);
        public Task<RestResp<string>> updateBookChapter(ChapterAddReqDto dto, long userId);
        public Task<RestResp<BookContentAboutRespDto>> getBookContentAbout(long chapterId);
        public Task<RestResp<long>> getPreChapterId(long chapterId);
        public Task<RestResp<long>> getNextChapterId(long chapterId);
        public BookChapterRespDto getChapter(long chapterId);
        public string getBookContent(long chapterId);

        public Task<RestResp<string>> addVisitCount(long bookId);

        public Task<List<BookRankRespDto>> listRankBooks(IOrderedQueryable<BookInfo> bQuery);

        public Task<RestResp<List<BookRankRespDto>>> listVisitRankBooks();

        public Task<RestResp<List<BookRankRespDto>>> listNewestRankBooks();

        public Task<RestResp<List<BookRankRespDto>>> listUpdateRankBooks();

        public Task<RestResp<PageRespDto<BookInfoRespDto>>> searchBooks(BookSearchReqDto dto);

    }
}
