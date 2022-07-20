using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RzNovel.Models;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Services
{
    public class BookService: IBookService
    {
        private RzNovelContext _context { get; set; }

        public BookService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<RestResp<string>> saveBook(BookAddReqDto dto)
        {
            // check Book Name Exists
            bool isBookExists = _context.BookInfos.Any(e => e.BookName.Equals(dto.bookName));
            if (isBookExists) return RestResp<string>.error("Book name is duplicated");

            BookInfo bookInfo = new BookInfo();
            bookInfo.AuthorId = 11111;
            bookInfo.AuthorName = "Thái Việt";
            bookInfo.CategoryId = dto.categoryId;
            bookInfo.CategoryName = dto.categoryName;
            bookInfo.BookName = dto.bookName;
            bookInfo.BookDesc = dto.bookDesc;
            bookInfo.PicUrl = dto.picUrl;
            bookInfo.CreateTime = bookInfo.UpdateTime = DateTime.Now;

            _context.BookInfos.Add(bookInfo);
            int num = await _context.SaveChangesAsync();
            if (num != 0) return RestResp<string>.ok($"{num} items has been created"); ;

            return RestResp<string>.error("database error"); ;

        }

        public async Task<RestResp<bool>> saveBookChapter(ChapterAddReqDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
