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

namespace RzNovel.Services.Impl
{

    public class UserService : IUserService
    {
        private RzNovelContext _context { get; set; }

        public UserService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<UserRegisterRespDto>> Register(UserRegisterReqDto dto)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Username = userInfo.NickName = dto.Username;
            userInfo.CreateTime = userInfo.UpdateTime = DateTime.Now;
            userInfo.Salt = "0";
            userInfo.Password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(dto.Password)).Select(s => s.ToString("x2")));
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            // build resp
            UserRegisterRespDto resp = new UserRegisterRespDto();
            resp.Id = userInfo.Id;
            resp.Token = "Hehe";
            return resp;

        }
    }
}
