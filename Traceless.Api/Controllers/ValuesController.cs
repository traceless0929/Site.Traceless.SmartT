using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Traceless.Api.Services.Interface;

namespace Traceless.Api.Controllers
{
    /// <summary>
    /// 这是个没啥用的控制器
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestService _testService;
        public ValuesController(ITestService testService)
        {
            _testService = testService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// 获取签到排名
        /// </summary>
        /// <param name="count"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [HttpGet]
        public Dictionary<string,DateTime> GetTopSign(int count,DateTime dt)
        {
            return _testService.GetTopSignByDay(dt, count);
        }
    }
}
