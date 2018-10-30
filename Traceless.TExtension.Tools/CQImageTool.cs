using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools
{
  public class CQImageTool
  {
    /// <summary>
    /// 通过CQ图片码获取图片HTTP地址
    /// </summary>
    /// <param name="imgCode"></param>
    /// <returns></returns>
    public static string GetCqImgCodeRawUrl(string imgCode)
    {
      try
      {
        var str = imgCode.Substring(15, imgCode.Length - 16);
        return GetCqImgRawUrl(str);
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// 通过CQIMG文件获取图片HTTP地址
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetCqImgRawUrl(string fileName)
    {
      try
      {
        var ret = ToolClass.fileToString(@"\data\image\" + fileName + ".cqimg");
        var res = ret.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var str = res.Where(p => p.StartsWith("url=")).Select(p => p.Substring(4)).FirstOrDefault();
        return str;
      }
      catch
      {
        return null;
      }
    }
  }
}
