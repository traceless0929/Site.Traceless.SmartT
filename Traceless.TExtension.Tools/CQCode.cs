using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools
{
    public class CQCode
    {
        /// <summary>
        /// 发送猜拳魔法表情
        /// </summary>
        /// <param name="type">猜拳结果的类型，暂不支持发送时自定义。该参数可被忽略。1 - 猜拳结果为石头2 - 猜拳结果为剪刀3 - 猜拳结果为布</param>
        /// <returns></returns>
        public static string SendRps(int type)
        {
            return $"[CQ:rps,type={type}]";
        }

        /// <summary>
        /// 发送掷骰子魔法表情
        /// </summary>
        /// <param name="type">{1}对应掷出的点数，暂不支持发送时自定义。该参数可被忽略。</param>
        /// <returns></returns>
        public static string SendDice(int type)
        {
            return $"[CQ:dice,type={type}]";
        }

        /// <summary>
        /// 本CQ码需加在消息的开头,匿名发消息（仅支持群消息使用）
        /// </summary>
        /// <param name="ignore">true时，代表不强制使用匿名，如果匿名失败将转为普通消息发送。false或ignore参数被忽略时，代表强制使用匿名，如果匿名失败将取消该消息的发送。</param>
        /// <returns></returns>
        public static string SendAnonymous(bool ignore=false)
        {
            return $"[CQ:anonymous,ignore={(ignore?"true":"false")}]";
        }

        /// <summary>
        /// 发送音乐
        /// </summary>
        /// <param name="type">音乐平台类型，目前支持qq、163、xiami</param>
        /// <param name="id">对应音乐平台的数字音乐id</param>
        /// <returns>音乐只能作为单独的一条消息发送</returns>
        public static string SendMusic(string type,int id)
        {
            return $"[CQ:music,type={type},id={id}]";
        }

        /// <summary>
        /// 发送音乐自定义分享
        /// </summary>
        /// <param name="url">分享链接，即点击分享后进入的音乐页面（如歌曲介绍页）</param>
        /// <param name="audio">音频链接（如mp3链接）</param>
        /// <param name="title">音乐的标题，建议12字以内</param>
        /// <param name="content">音乐的简介，建议30字以内。该参数可被忽略</param>
        /// <param name="image">音乐的封面图片链接。若参数为空或被忽略，则显示默认图片</param>
        /// <returns>音乐自定义分享只能作为单独的一条消息发送</returns>
        public static string SendCusMusic(string url, string audio, string title, string image="", string content="")
        {
            return $"[CQ:music,type=custom,url={url},audio={audio},title={title},content={content},image={image}]";

        }

        /// <summary>
        /// 发送链接分享
        /// </summary>
        /// <param name="url">分享链接</param>
        /// <param name="title">分享的标题，建议12字以内</param>
        /// <param name="image">分享的图片链接。若参数为空或被忽略，则显示默认图片param>
        /// <param name="content">分享的简介，建议30字以内。该参数可被忽略</param>
        /// <returns></returns>
        public static string SendLink(string url, string title, string image="", string content = "")
        {
            return $"[CQ:share,url={url},title={title},content={content},image={image}]";
        }

        /// <summary>
        /// 获取QQ头像
        /// </summary>
        /// <param name="qq">QQ号</param>
        /// <returns></returns>
        public static string GetQQHead(string qq)
        {
            return $"https://q2.qlogo.cn/headimg_dl?dst_uin={qq}&spec=100";
        }
    }
}
