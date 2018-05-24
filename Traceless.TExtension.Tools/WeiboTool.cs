using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Traceless.TExtension.Tools.Model;

namespace Traceless.TExtension.Tools
{
    public class WeiboTool
    {
        /// <summary>
        /// 获取微博话题列表(使用微博话题墙)
        /// </summary>
        /// <param name="topicNmae">话题名</param>
        /// <param name="tragetName">指定发送者名称</param>
        /// <returns></returns>
        public static List<WeiBoContentItem> GetWeiBoTopicContent(string topicNmae,string tragetName = "")
        {
            List<WeiBoContentItem> ret = new List<WeiBoContentItem>();
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("http://widget.weibo.com/topics/topic_vote_base.php?tag=" + topicNmae);

            HtmlNodeCollection ContentList = doc.DocumentNode.SelectNodes("//div[@class='weibo_content']");
            var sourceList = ContentList.Where(p => p.InnerHtml.Contains("title=\"" + tragetName));
            if (sourceList != null)
            {
                
                foreach (var item in sourceList)
                {
                    var listItem = new WeiBoContentItem();
                    HtmlNodeCollection ContentNodes = item.SelectNodes("./div[@class='weibo_text']");
                    var UserInfo =  ContentNodes.FirstOrDefault()?.SelectNodes("./a[@class='user_name']");
                    listItem.Author = UserInfo.FirstOrDefault()?.Attributes["title"].Value;
                    var contentTxt = ContentNodes.FirstOrDefault()?.SelectNodes("./cite[@class='user_words']");
                    listItem.ContentStr = contentTxt.FirstOrDefault()?.InnerText.Substring(1).Replace(" ​","").Replace(@"&middot;", "·");
                    HtmlNodeCollection ImageNodes = item.SelectNodes("./div[@class='weibo_img_container']");
                    listItem.Pic = "http:"+ImageNodes.FirstOrDefault()?.SelectNodes("./img[@class='WB_big_cursor']").FirstOrDefault()?.Attributes["src"].Value.Replace("thumbnail", "bmiddle");
                    ret.Add(listItem);
                }

            }
            return ret;
        }

    }
}
