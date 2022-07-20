using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzNovel.Services;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;

namespace RzNovel.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public TestController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // GET: api/APIHomeBooks
        [Route("~/api/test/home_books")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeBookRespDto>>> GetHomeBooks()
        {
            return await _homeService.ListHomeBooks();
        }
    }
}
