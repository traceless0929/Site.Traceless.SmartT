using System;

namespace Traceless.Util
{
    public static class TimeTool
    {
        public static long ConvertToTimeStamp(this DateTime dt)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            long timeStamp = (long)(dt - startTime).TotalMilliseconds; // 相差毫秒数
            return timeStamp;
        }
    }
}
