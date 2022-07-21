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
    [Route("author")]
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IUserService userService, IAuthorService authorService, IBookService bookService)
        {
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
        }

        [Route("manage")]
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            // check Status
            RestResp<string> res = await _authorService.GetStatus(userId);
            if ("non_exists".Equals(res.message)) return Redirect("register");
            ViewBag.Message = res.message;
            return View();
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAuthorRegister(AuthorRegisterReqDto dto)
        {
            dto.userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _authorService.Register(dto);
        }

        [Route("manage/add_book")]
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            ViewBag.Categories = (await _bookService.listBookCategories()).data;
            return View();
        }

        [Route("manage/add_book")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAddBook(BookAddReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _bookService.saveBook(dto, userId);
        }
    }
}
