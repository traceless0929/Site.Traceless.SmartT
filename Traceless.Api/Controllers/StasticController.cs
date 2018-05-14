using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Traceless.Api.Services.Interface;

namespace Traceless.Api.Controllers
{
    /// <summary>
    /// 统计相关
    /// </summary>
    [Route("api/[controller]")]
    public class StasticController : Controller
    {
        private readonly IStasticService _stasticService;
        public StasticController(IStasticService stasticService)
        {
            _stasticService = stasticService;
        }

        /// <summary>
        /// 获取签到排名
        /// </summary>
        /// <param name="count"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <remarks>按照时间早到晚返回 {时间戳}-{QQ} 字典</remarks>
        [HttpGet("GetTopSign")]
        public Dictionary<long,string> GetTopSign(int count,DateTime dt)
        {
            return _stasticService.GetTopSignByDay(dt, count);
        }
    }
}
