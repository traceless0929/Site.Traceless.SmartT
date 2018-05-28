using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools.Model
{
    public class WeiBoContentItem
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 微博正文
        /// </summary>
        public string ContentStr { get; set; }
        /// <summary>
        /// 微博图片
        /// </summary>
        public string Pic { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
