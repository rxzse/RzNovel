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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authorService;
        private readonly IAdminService _adminService;
        private readonly IBookService _bookService;
        

        public AdminController(IUserService userService, IAuthorService authorService, IBookService bookService, IAdminService adminService)
        {
            _userService = userService;
            _authorService = authorService;
            _bookService = bookService;
            _adminService = adminService;


        }

        [Route("authors")]
        [HttpGet]
        public async Task<IActionResult> ManageAuthor(PageReqDto dto)
        {
            
            ViewData["BigTitle"] = "Quản lý Author";
            ViewData["SmallTitle"] = "Duyệt quyền tác giả";

            // get all books by AuthorId
            var pageRes = (await _adminService.listAuthors(dto)).data;
            ViewBag.Page = pageRes;
            return View();
        }

        [Route("update_author")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostUpdateAuthor(AdminUpdAuthorDto dto)
        {
            return await _adminService.updateAuthorStatus(dto);
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> ManageCategory(PageReqDto dto)
        {
            
            ViewData["BigTitle"] = "Quản lý Categories";
            ViewData["SmallTitle"] = "Sáng tạo thế giới của bạn";

            //  
            ViewBag.ButtonCustom = true;
            ViewBag.ButtonTitle = "Thêm Category";
            ViewBag.ButtonAction = "/admin/add_category";

            // get all books by AuthorId
            ViewBag.listCategories = _bookService.listBookCategories().data;
            
            return View();
        }

        [Route("add_category")]
        [HttpGet]
        public async Task<IActionResult> AddCategory(PageReqDto dto)
        {

            ViewData["BigTitle"] = "Tạo mới Category";
            ViewData["SmallTitle"] = "Sáng tạo thế giới của bạn";

            //  
            ViewBag.ButtonCustom = true;
            ViewBag.ButtonTitle = "Thêm Category";
            ViewBag.ButtonAction = "/admin/add_category";

            return View();
        }

        [Route("add_category")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostAddCategory(AdminAddCategoryDto dto)
        {
            return await _adminService.addCategory(dto);
        }

        [Route("update_category")]
        [HttpPost]
        public async Task<ActionResult<RestResp<string>>> PostUpdateCategory(AdminAddCategoryDto dto)
        {
            return await _adminService.updateCategory(dto);
        }

    }
}
