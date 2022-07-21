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

    public class UserService : IUserService
    {
        private RzNovelContext _context { get; set; }

        public UserService(RzNovelContext context)
        {
            _context = context;
        }

        public async Task<RestResp<UserRegisterRespDto>> Register(UserRegisterReqDto dto)
        {
            // check Book Name Exists
            bool isUserNameExists = _context.UserInfos.Any(e => e.Username.Equals(dto.username));
            if (isUserNameExists) return RestResp<UserRegisterRespDto>.error("Duplicated username");

            UserInfo userInfo = new UserInfo();
            userInfo.Username = userInfo.NickName = dto.username;
            userInfo.CreateTime = userInfo.UpdateTime = DateTime.Now;
            userInfo.Salt = "0";
            userInfo.Status = 1;
            userInfo.Password = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(dto.password)).Select(s => s.ToString("x2")));
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            // build resp
            UserRegisterRespDto resp = new UserRegisterRespDto();
            resp.id = userInfo.Id;
            resp.userName = userInfo.Username;
            return RestResp<UserRegisterRespDto>.ok(resp);

        }

        public async Task<RestResp<UserLoginRespDto>> Login(UserLoginReqDto dto)
        {
            if (string.IsNullOrEmpty(dto.password) || string.IsNullOrEmpty(dto.username)) return RestResp<UserLoginRespDto>.error("username|password");
            // check userInfo
            UserInfo userInfo = _context.UserInfos.FirstOrDefault(e => e.Username.Equals(dto.username));
            if (userInfo is null) return RestResp<UserLoginRespDto>.error("username not exists");
            
            string passHash = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(dto.password)).Select(s => s.ToString("x2")));
            if (!userInfo.Password.Equals(passHash)) return RestResp<UserLoginRespDto>.error("Wrong password");

            UserLoginRespDto resp = new UserLoginRespDto();
            resp.id = userInfo.Id;
            resp.nickName = userInfo.NickName;
            resp.isAdmin = "rxzse".Equals(userInfo.Username) ? true : false;

            return RestResp<UserLoginRespDto>.ok(resp);
        }
    }
}
