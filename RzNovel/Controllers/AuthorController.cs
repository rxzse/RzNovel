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
        public async Task<IActionResult> Manage(PageReqDto dto)
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
            ViewData["BigTitle"] = "Tạo truyện mới";
            ViewData["SmallTitle"] = "Sáng tạo thế giới của bạn";
            return View();
        }

        [Route("manage/add_book")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAddBook(BookAddReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _bookService.saveBook(dto, userId);
        }

        [Route("manage/edit_book")]
        [HttpGet]
        public async Task<IActionResult> EditBook(long bookId)
        {
            BookInfoRespDto bRes = (await _bookService.getBookById(bookId)).data;
            ViewData["BigTitle"] = "Chỉnh sửa truyện";
            ViewData["SmallTitle"] = bRes.bookName;
            return View(bRes);
        }

        [Route("manage/edit_book")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostEditBook(BookAddReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _bookService.updateBook(dto, userId);
        }

        /// <summary>
        /// Manage Book Chapter
        /// </summary>
        /// <returns></returns>

        [Route("manage/chapter")]
        [HttpGet]
        public async Task<IActionResult> BookChapter(PageReqDto dto, long bookId)
        {
            

            BookInfoRespDto bRes = (await _bookService.getBookById(bookId)).data;
            PageRespDto<BookChapterRespDto> pageRes = (await _bookService.listBookChapters(dto, bookId)).data;
            ViewBag.Page = pageRes;

            ViewData["BigTitle"] = "Truyện: " + bRes.bookName;
            ViewData["SmallTitle"] = "Quản lý Chapter";
            ViewBag.ButtonCustom = true;
            ViewBag.ButtonTitle = "Thêm Chapter";
            ViewBag.ButtonAction = "/author/manage/add_chapter?bookId=" + bookId;

            return View();
        }

        [Route("manage/add_chapter")]
        [HttpGet]
        public async Task<IActionResult> AddBookChapter(long bookId)
        {
            ViewBag.ButtonCustom = true;
            ViewBag.ButtonTitle = "Thêm Chapter";
            ViewBag.ButtonAction = "/author/manage/add_chapter?bookId=" + bookId;
            ///////////////////////
            BookInfoRespDto bRes = (await _bookService.getBookById(bookId)).data;
            ViewData["BigTitle"] = "Truyện: " + bRes.bookName;
            ViewData["SmallTitle"] = "Tạo Chapter mới";
            ViewBag.BookInfo = bRes;

            return View();
        }

        [Route("manage/add_chapter")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAddBookChapter(ChapterAddReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _bookService.saveBookChapter(dto, userId);
        }

        [Route("manage/edit_chapter")]
        [HttpGet]
        public async Task<IActionResult> EditBookChapter(long chapterId)
        {
            BookContentAboutRespDto bRes = (await _bookService.getBookContentAbout(chapterId)).data;
            ViewData["BigTitle"] = "Truyện: " + bRes.bookInfo.bookName;
            ViewData["SmallTitle"] = $"Chỉnh sửa Chapter: [{bRes.chapterInfo.chapterNum}] {bRes.chapterInfo.chapterName}";
            ViewBag.ChapterInfo = bRes;
            //  
            ViewBag.ButtonCustom = true;
            ViewBag.ButtonTitle = "Thêm Chapter";
            ViewBag.ButtonAction = "/author/manage/add_chapter?bookId=" + bRes.bookInfo.id;
            return View();
        }

        [Route("manage/edit_chapter")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostEditBookChapter(ChapterAddReqDto dto)
        {
            long userId = long.Parse(HttpContext.User.Claims.First(e => e.Type.Equals("Id")).Value);
            return await _bookService.updateBookChapter(dto, userId);
        }
    }
}
