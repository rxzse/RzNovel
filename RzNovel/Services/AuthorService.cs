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

namespace RzNovel.Services
{

    public class AuthorService : IAuthorService
    {
        private RzNovelContext _context { get; set; }

        public AuthorService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<RestResp<string>> Register(AuthorRegisterReqDto dto)
        {
            // Author Exists
            AuthorInfo authorInfo = _context.AuthorInfos.FirstOrDefault(e => e.UserId == dto.userId || e.PenName.Equals(dto.penName));
            if (authorInfo is not null) return RestResp<string>.error("duplicate");
            authorInfo = new AuthorInfo();
            authorInfo.UserId = dto.userId;
            authorInfo.PenName = dto.penName;
            authorInfo.InviteCode = "0";
            authorInfo.CreateTime = authorInfo.UpdateTime = DateTime.Now;

            _context.AuthorInfos.Add(authorInfo);
            await _context.SaveChangesAsync();
            return RestResp<string>.ok(authorInfo.PenName);

        }

 
        public async Task<RestResp<string>> GetStatus(long userId)
        {
            AuthorInfo authorInfo = _context.AuthorInfos.FirstOrDefault(e => e.UserId == userId);
            if (authorInfo is null) return RestResp<string>.error("non_exists");
            if (authorInfo.Status == 0) return RestResp<string>.error("inactive");
            return RestResp<string>.ok("active");
        }
    }
}
