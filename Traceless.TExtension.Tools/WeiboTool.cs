using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hawk.ETL.Crawlers;
using HtmlAgilityPack;
using Traceless.TExtension.Tools.Model;

namespace Traceless.TExtension.Tools
{
    public class WeiboTool
    {
        /// <summary>
        /// 获取话题Id
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        public static string GetWeiBoTopicId(string topicName)
        {
            string topicUrl = "";
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("https://s.weibo.com/apps/" + topicName+ "&pagetype=topic&topic=1&Refer=weibo_topic");
            HtmlNodeCollection ContentList = doc.DocumentNode.SelectNodes("//a[@suda-data='key=t_blog_search_interest&value=interest_topic_icon']");
            var item = ContentList.FirstOrDefault();
            if (item == null) return null;
            else
            {
                var res = item.Attributes["href"];
                topicUrl = res.Value;
            }

            var ret = topicUrl.Substring(topicUrl.LastIndexOf('/')+1);
            return ret;
        }

        /// <summary>
        /// 获取微博话题内容列表(使用微博话题api),此接口返回内容详细，非常好用
        /// </summary>
        /// <param name="topicId">话题id</param>
        /// <param name="tragetName">指定发送者名称</param>
        /// <returns></returns>
        public static List<WeiBoContentItem> GetWeiBoTopicContentV1(string topicId, string targetName = "")
        {
            var res = JavaScriptAnalyzer.Decode(ToolClass.GetAPI("https://m.weibo.cn/api/container/getIndex?containerid=" + topicId));
            var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<WeiBoTopicRes>(res);
            var card_Groups = new List<WeiBoTopicRes.Card_Group>();
            ret.data.cards.Where(p => p.card_group != null).Select(p => p).ToList().ForEach(
                c =>
                {
                    card_Groups.AddRange(c.card_group);
                });

            List<WeiBoContentItem> theres = new List<WeiBoContentItem>();
            card_Groups.ForEach(p =>
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(p.mblog.text);
                WeiBoContentItem item = new WeiBoContentItem
                {
                    Pic = p.mblog.original_pic,
                    Author=p.mblog.user.screen_name,
                    ContentStr= htmlDocument.DocumentNode?.InnerText
                };
                if (p.mblog.created_at.Contains("分钟"))
                {
                    var getNum =Convert.ToInt32(p.mblog.created_at.Replace("分钟前", ""));
                    item.Time = DateTime.Now.AddMinutes(-getNum);
                }
                else if (p.mblog.created_at.Contains("小时"))
                {
                    var getNum = Convert.ToInt32(p.mblog.created_at.Replace("小时前", ""));
                    item.Time = DateTime.Now.AddHours(-getNum);
                }
                else
                {
                    item.Time = Convert.ToDateTime(p.mblog.created_at);
                }
                item.TopicId = Convert.ToInt64(p.mblog.id);

                theres.Add(item);
            });
            return theres.Where(p=>p.Author.Trim().Contains(targetName)).OrderByDescending(p=>p.TopicId).ToList();
        }

        /// <summary>
        /// 获取微博话题内容列表(使用微博话题墙)
        /// </summary>
        /// <param name="topicNmae">话题名</param>
        /// <param name="tragetName">指定发送者名称</param>
        /// <returns></returns>
        public static List<WeiBoContentItem> GetWeiBoTopicContent(string topicName,string tragetName = "")
        {
            List<WeiBoContentItem> ret = new List<WeiBoContentItem>();
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("http://widget.weibo.com/topics/topic_vote_base.php?tag=" + topicName);

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
