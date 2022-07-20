using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzNovel.Models;
using RzNovel.DTO.Resp;

namespace RzNovel.Services
{
    public interface IHomeService
    {
        public Task<List<HomeBookRespDto>> ListHomeBooks();
    }
}
