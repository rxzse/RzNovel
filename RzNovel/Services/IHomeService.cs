﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RzNovel.Models;
using RzNovel.DTO.Resp;
using RzNovel.Common.Resp;

namespace RzNovel.Services
{
    public interface IHomeService
    {
        public Task<RestResp<List<HomeBookRespDto>>> ListHomeBooks();
    }
}
