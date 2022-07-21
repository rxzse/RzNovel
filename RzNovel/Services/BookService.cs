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

        public async Task<RestResp<bool>> saveBookChapter(ChapterAddReqDto dto)
        {
            throw new NotImplementedException();
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
            _context.Entry(bookInfo).State = EntityState.Modified;
            int num = await _context.SaveChangesAsync();
            if (num != 0) return RestResp<string>.ok("success"); ;
            return RestResp<string>.error("database error");
        }
    }
}
