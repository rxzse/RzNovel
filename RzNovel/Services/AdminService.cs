using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using RzNovel.DTO.Req;
using RzNovel.DTO.Resp;
using RzNovel.Services;
using RzNovel.Models;
using System.Text;
using RzNovel.Common.Resp;
using Microsoft.EntityFrameworkCore;

namespace RzNovel.Services
{

    public class AdminService : IAdminService
    {
        private RzNovelContext _context { get; set; }

        public AdminService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<RestResp<string>> updateAuthorStatus(AdminUpdAuthorDto dto)
        {
            var authorInfo = _context.AuthorInfos.FirstOrDefault(e => e.Id == dto.authorId);
            if (authorInfo is null) return RestResp<string>.error("author not exists");
            authorInfo.Status = dto.status;
            authorInfo.UpdateTime = DateTime.Now;
            _context.Entry(authorInfo).State = EntityState.Modified;
            int num = await _context.SaveChangesAsync();
            if (num > 0) return RestResp<string>.ok("success");
            return RestResp<string>.error("database error");
        }

        public async Task<RestResp<string>> addCategory(AdminAddCategoryDto dto)
        {
            // Category Exists
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(e => e.Name.ToLower().Equals(dto.name));
            if (bookCategory is not null) return RestResp<string>.error("category duplicated");

            var newBc = new BookCategory();
            newBc.Name = dto.name.Trim();
            newBc.Sort = dto.sort;
            newBc.WorkDirection = 0;
            newBc.CreateTime = newBc.UpdateTime = DateTime.Now;
            await _context.BookCategories.AddAsync(newBc);
            int num = await _context.SaveChangesAsync();
            if (num > 0) return RestResp<string>.ok("success");
            return RestResp<string>.error("database error");
        }

        public async Task<RestResp<string>> updateCategory(AdminAddCategoryDto dto)
        {
            // Category Exists
            var bookCategory = await _context.BookCategories.FirstOrDefaultAsync(e => e.Id == dto.id);
            if (bookCategory is null) return RestResp<string>.error("category not exists");

            bookCategory.Sort = dto.sort;
            bookCategory.UpdateTime = DateTime.Now;

            _context.Entry(bookCategory).State = EntityState.Modified;
            int num = await _context.SaveChangesAsync();
            if (num > 0) return RestResp<string>.ok("success");
            return RestResp<string>.error("database error");
        }

        public async Task<RestResp<PageRespDto<AuthorInfoRespDto>>> listAuthors(PageReqDto dto)
        {
            var bQuery = _context.AuthorInfos.OrderByDescending(e => e.CreateTime);

            // paginating
            int startIndex = 0;
            if (dto.pageNum != 1)
            {
                startIndex = dto.pageNum - 1;
                startIndex = startIndex * dto.pageSize;
            }
            var pageQuery = bQuery.Skip(startIndex).Take(dto.pageSize).ToList();

            // bind List 
            List<AuthorInfoRespDto> res = new List<AuthorInfoRespDto>();
            pageQuery.ForEach(e =>
            {
                AuthorInfoRespDto ai = new AuthorInfoRespDto();
                ai.authorId = e.Id;
                ai.penName = e.PenName;
                ai.userId = e.UserId;
                ai.userName = null;
                ai.status = e.Status;
                ai.createTime = (DateTime)e.CreateTime;
                ai.updateTime = (DateTime)e.UpdateTime;

                // find user by userId
                var userInfo = _context.UserInfos.FirstOrDefault(e => e.Id == ai.userId);
                if (userInfo is not null) ai.userName = userInfo.Username;
                res.Add(ai);
            });

            return RestResp<PageRespDto<AuthorInfoRespDto>>.ok(PageRespDto<AuthorInfoRespDto>.of(dto.pageNum, dto.pageSize, bQuery.Count(), res));

        }


    }
}
