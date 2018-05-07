using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traceless.Api.Services.Interface
{
    /// <summary>
    /// 统计相关接口
    /// </summary>
    public interface IStasticService
    {
        Dictionary<DateTime, string> GetTopSignByDay(DateTime dt, int count);
    }
}
