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
    [Route("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AdminController(IUserService userService, IAuthorService authorService, IBookService bookService)
        {
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
            
        }

        [Route("author")]
        [HttpGet]
        public async Task<IActionResult> ManageAuthor(PageReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            // check Status
            RestResp<string> res = await _authorService.GetStatus(userId);
            if ("non_exists".Equals(res.message)) return Redirect("register");
            ViewBag.Message = res.message;
            ViewData["BigTitle"] = "Quản lý truyện";
            ViewData["SmallTitle"] = "Sáng tạo thế giới của bạn";

            // get all books by AuthorId
            PageRespDto<BookInfoRespDto> pageRes = (await _bookService.listAuthorBooks(dto, userId)).data;
            ViewBag.Page = pageRes;
            return View();
        }

        [Route("category")]
        [HttpGet]
        public async Task<IActionResult> ManageCategory(PageReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            // check Status
            RestResp<string> res = await _authorService.GetStatus(userId);
            if ("non_exists".Equals(res.message)) return Redirect("register");
            ViewBag.Message = res.message;
            ViewData["BigTitle"] = "Quản lý truyện";
            ViewData["SmallTitle"] = "Sáng tạo thế giới của bạn";

            // get all books by AuthorId
            PageRespDto<BookInfoRespDto> pageRes = (await _bookService.listAuthorBooks(dto, userId)).data;
            ViewBag.Page = pageRes;
            return View();
        }


    }
}
