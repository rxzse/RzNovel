using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;


using RzNovel.Services;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public HomeController(IUserService userService, IAuthorService authorService, IBookService bookService)
        {
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
            
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.listNewestRankBooks = (await _bookService.listNewestRankBooks()).data;
            ViewBag.listVisitRankBooks = (await _bookService.listVisitRankBooks()).data;
            ViewBag.listUpdateRankBooks = (await _bookService.listUpdateRankBooks()).data;
            return View();
        }

        [Route("search")]
        public async Task<IActionResult> Search(BookSearchReqDto dto)
        {
            PageRespDto<BookInfoRespDto> pageRes = (await _bookService.searchBooks(dto)).data;
            ViewBag.Page = pageRes;
            return View();
        }

    }
}
