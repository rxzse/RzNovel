using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RzNovel.Models;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Services
{
    public class HomeService: IHomeService
    {
        private RzNovelContext _context { get; set; }

        public HomeService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<RestResp<List<HomeBookRespDto>>> ListHomeBooks() 
        {
            List<HomeBookRespDto> results = new List<HomeBookRespDto>();

            // get homeBook from database
            List<HomeBook> homeBooks = await _context.HomeBooks.OrderBy(e => e.Sort).ToListAsync();
            List<long> bookIds = homeBooks.Select(e => e.BookId).ToList();

            // select Book from database
            var bookInfosQueries = from bi in _context.BookInfos where bookIds.Contains(bi.Id) select bi;
            List<BookInfo> bookInfos = await bookInfosQueries.ToListAsync();

            Dictionary<long, BookInfo> bookInfosMap = new Dictionary<long, BookInfo>();
            bookInfos.ForEach(e => bookInfosMap.Add(e.Id, e));

            if (bookInfos.Count > 0)
            {
                
                homeBooks.ForEach(e =>
                {
                    HomeBookRespDto res = new HomeBookRespDto();
                    BookInfo bi = bookInfosMap[e.BookId];
                    res.type = e.Type;
                    res.bookId = e.BookId;
                    res.bookName = bi.BookName;
                    res.picUrl = bi.PicUrl;
                    res.authorName = bi.AuthorName;
                    res.bookDesc = bi.BookDesc;
                    results.Add(res);
                });
                
            }
            return RestResp<List<HomeBookRespDto>>.ok(results);
        }
    }
}
