using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzNovel.Services;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly IBookService _bookService;

        public TestController(IHomeService homeService, IBookService bookService)
        {
            _homeService = homeService;
            _bookService = bookService;
        }

        // GET: api/APIHomeBooks
        [Route("~/api/test/home_books")]
        [HttpGet]
        public async Task<ActionResult<RestResp<List<HomeBookRespDto>>>> GetHomeBooks()
        {
            return await _homeService.ListHomeBooks();
        }

        [Route("~/api/test/save_book")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostSaveBook(BookAddReqDto dto)
        {
            
            

            return await _bookService.saveBook(dto);
        }
    }
}
