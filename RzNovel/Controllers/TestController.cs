﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;

        public TestController(IHomeService homeService, IBookService bookService, IUserService userService, IAuthorService authorService)
        {
            _homeService = homeService;
            _bookService = bookService;
            _userService = userService;
            _authorService = authorService;
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



            return null;
        }

        [Route("~/api/test/login")]
        [HttpPost]
        public async Task<ActionResult<RestResp<UserLoginRespDto>>> PostLogin(UserLoginReqDto dto)
        {
            return await _userService.Login(dto);
        }

        [Route("~/api/test/register")]
        [HttpPost]
        public async Task<ActionResult<RestResp<UserRegisterRespDto>>> PostRegister(UserRegisterReqDto dto)
        {
            return await _userService.Register(dto);
        }

        [Route("~/api/test/author/register")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAuthorRegister(AuthorRegisterReqDto dto)
        {
            dto.userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return RestResp<string>.ok(dto.userId.ToString());
            return await _authorService.Register(dto);
        }
    }
}
