using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RzNovel.Models;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;
using Microsoft.AspNetCore.Http;

namespace RzNovel.Services
{
    public class BookService: IBookService
    {
        private RzNovelContext _context { get; set; }

        public BookService(RzNovelContext context)
        {
            _context = context;
        }

        public RestResp<List<BookCategoryRespDto>> listBookCategories()
        {
            List<BookCategoryRespDto> res = new List<BookCategoryRespDto>();
             _context.BookCategories.ToList().ForEach(e => {
                BookCategoryRespDto ii = new BookCategoryRespDto();
                    ii.id = e.Id;
                    ii.name = e.Name;
                    res.Add(ii);
                });
            return RestResp<List<BookCategoryRespDto>>.ok(res);
        }

        public async Task<RestResp<string>> saveBook(BookAddReqDto dto, long userId)
        {
            // check Book Name Exists
            bool isBookExists = _context.BookInfos.Any(e => e.BookName.Equals(dto.bookName));
            if (isBookExists) return RestResp<string>.error("bookName duplicated");

            BookInfo bookInfo = new BookInfo();

            // bind userId
            AuthorInfo authorInfo = _context.AuthorInfos.FirstOrDefault(e => e.UserId == userId);

            bookInfo.AuthorId = authorInfo.Id;
            bookInfo.AuthorName = authorInfo.PenName;
            bookInfo.CategoryId = dto.categoryId;
            bookInfo.CategoryName = dto.categoryName;
            bookInfo.BookName = dto.bookName;
            bookInfo.BookDesc = dto.bookDesc;
            bookInfo.PicUrl = "#";
            bookInfo.CreateTime = bookInfo.UpdateTime = DateTime.Now;

            _context.BookInfos.Add(bookInfo);
            int num = await _context.SaveChangesAsync();
            if (num != 0) return RestResp<string>.ok("success"); ;

            return RestResp<string>.error("database error");

        }

        public async Task<RestResp<string>> saveBookChapter(ChapterAddReqDto dto, long userId)
        {
            int num = 0;
            AuthorInfo authorInfo = await _context.AuthorInfos.FirstOrDefaultAsync(e => e.UserId == userId);
            BookInfo bookInfo = await _context.BookInfos.FirstOrDefaultAsync(e => e.Id == dto.bookId);
            if (authorInfo is null || bookInfo is null) return RestResp<string>.error("invalid operation");
            if (bookInfo.AuthorId != authorInfo.Id) return RestResp<string>.error("unauthorize");
            // 1 Query the latest chapter number
            int chapterNum = 0;
            var bookChapter = await _context.BookChapters.Where(e => e.BookId == dto.bookId).OrderByDescending(e => e.ChapterNum).FirstOrDefaultAsync();
            if (bookChapter is not null) chapterNum = bookChapter.ChapterNum + 1;
            // New book Chapter
            BookChapter newBookChapter = new BookChapter();
            newBookChapter.BookId = dto.bookId;
            newBookChapter.ChapterNum = chapterNum;
            newBookChapter.ChapterName = dto.chapterName;
            newBookChapter.WordCount = dto.chapterContent.Length;
            newBookChapter.CreateTime = newBookChapter.UpdateTime = DateTime.Now;
            _context.BookChapters.Add(newBookChapter);
            num += await _context.SaveChangesAsync();

            // Save chapter content
            BookContent bookContent = new BookContent();
            bookContent.ChapterId = newBookChapter.Id;
            bookContent.Content = dto.chapterContent;
            bookContent.CreateTime = bookContent.UpdateTime = DateTime.Now;
            _context.BookContents.Add(bookContent);
            num += await _context.SaveChangesAsync();

            // Update bookInfo
            bookInfo.LastChapterId = newBookChapter.Id;
            bookInfo.LastChapterName = newBookChapter.ChapterName;
            bookInfo.LastChapterUpdateTime = DateTime.Now;
            bookInfo.WordCount = bookInfo.WordCount + newBookChapter.WordCount;
            newBookChapter.UpdateTime = DateTime.Now;
            
            _context.Entry(bookInfo).State = EntityState.Modified;
            num += await _context.SaveChangesAsync();

            // submit
            if (num != 0) return RestResp<string>.ok("success"); ;
            return RestResp<string>.error("database error");
        }

        public async Task<RestResp<PageRespDto<BookInfoRespDto>>> listAuthorBooks(PageReqDto dto, long userId)
        {
            AuthorInfo authorInfo = _context.AuthorInfos.FirstOrDefault(e => e.UserId == userId);
            var bQuery = _context.BookInfos.Where(e => e.AuthorId == authorInfo.Id).OrderByDescending(e => e.CreateTime);

            // paginating
            int startIndex = 0;
            if (dto.pageNum != 1)
            {
                startIndex = dto.pageNum - 1;
                startIndex = startIndex * dto.pageSize;
            }
            var pageQuery = bQuery.Skip(startIndex).Take(dto.pageSize).ToList();

            // bind List 
            List<BookInfoRespDto> res = new List<BookInfoRespDto>();
            pageQuery.ForEach(e =>
            {
                BookInfoRespDto bi = new BookInfoRespDto();
                bi.id = e.Id;
                bi.bookName = e.BookName;
                bi.categoryName = e.CategoryName;
                bi.wordCount = e.WordCount;
                bi.visitCount = e.VisitCount;
                bi.bookStatus = e.BookStatus;
                bi.updateTime = (DateTime)e.UpdateTime;
                bi.lastChapterId = 0;
                bi.lastChapterName = e.LastChapterName;
                res.Add(bi);
            });

            return RestResp<PageRespDto<BookInfoRespDto>>.ok(PageRespDto<BookInfoRespDto>.of(dto.pageNum, dto.pageSize, bQuery.Count(), res));
        }

        public async Task<RestResp<BookInfoRespDto>> getBookById(long bookId)
        {
            BookInfo bookInfo = await _context.BookInfos.FirstOrDefaultAsync(e => e.Id == bookId);
            BookInfoRespDto bi = new BookInfoRespDto();
            bi.id = bookInfo.Id;
            
            bi.bookName = bookInfo.BookName;
            bi.categoryName = bookInfo.CategoryName;
            bi.wordCount = bookInfo.WordCount;
            bi.visitCount = bookInfo.VisitCount;
            bi.bookDesc = bookInfo.BookDesc;
            bi.bookStatus = bookInfo.BookStatus;
            bi.updateTime = (DateTime)bookInfo.UpdateTime;

            return RestResp<BookInfoRespDto>.ok(bi);
        }

        public async Task<RestResp<string>> updateBook(BookAddReqDto dto, long userId)
        {
            // check book <- userId
            AuthorInfo authorInfo = await _context.AuthorInfos.FirstOrDefaultAsync(e => e.UserId == userId);
            BookInfo bookInfo = await _context.BookInfos.FirstOrDefaultAsync(e => e.AuthorId == authorInfo.Id && e.Id == dto.id);
            if (bookInfo is null) return RestResp<string>.error("book not exists");
            bookInfo.BookName = dto.bookName;
            bookInfo.BookDesc = dto.bookDesc;
            bookInfo.BookStatus = dto.bookStatus;
            bookInfo.UpdateTime = DateTime.Now;
            _context.Entry(bookInfo).State = EntityState.Modified;
            int num = await _context.SaveChangesAsync();
            if (num != 0) return RestResp<string>.ok("success"); ;
            return RestResp<string>.error("database error");
        }
    }
}
