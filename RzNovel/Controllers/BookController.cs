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
    [Route("book")]
    public class BookController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public BookController(IUserService userService, IAuthorService authorService, IBookService bookService)
        {
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
            
        }

        [Route("details/{bookId}")]
        [HttpGet]
        public async Task<IActionResult> BookDetails(long bookId)
        {

            BookInfoRespDto bookInfoResp = (await _bookService.getBookById(bookId)).data;
            List<BookChapterRespDto> listChapters = (await _bookService.listChapters(bookId)).data;
            BookChapterAboutRespDto lastChapterAbout = (await _bookService.getLastChapterAbout(bookId)).data;
            ViewBag.bookInfoResp = bookInfoResp;
            ViewBag.listChapters = listChapters;
            ViewBag.lastChapterAbout = lastChapterAbout;
            ViewData["Title"] = "Truyện - " + bookInfoResp.bookName;
            return View();
        }

        [Route("read/{chapterId}")]
        [HttpGet]
        public async Task<IActionResult> BookContent(long chapterId)
        {
            BookContentAboutRespDto bookContent = (await _bookService.getBookContentAbout(chapterId)).data;
            ViewData["Title"] = "Truyện - " + bookContent.bookInfo.bookName + " - Chương " + (bookContent.chapterInfo.chapterNum + 1);
            ViewBag.BookContent = bookContent;
            ViewBag.PreId = (await _bookService.getPreChapterId(chapterId)).data;
            ViewBag.NextId = (await _bookService.getNextChapterId(chapterId)).data;
            return View();
        }
    }
}
