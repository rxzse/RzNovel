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

        public async Task<RestResp<List<BookCategoryRespDto>>> listBookCategories()
        {
            List<BookCategoryRespDto> res = new List<BookCategoryRespDto>();
            await _context.BookCategories.ForEachAsync(e => {
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

            return RestResp<string>.error("database error"); ;

        }

        public async Task<RestResp<bool>> saveBookChapter(ChapterAddReqDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
