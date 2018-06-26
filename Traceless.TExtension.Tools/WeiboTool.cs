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
            HtmlDocument doc = webClient.Load("https://s.weibo.com/weibo/" + topicName + "&Refer=weibo_weibo&xsort=time&realtimeweibo=1");
            var ress = JavaScriptAnalyzer.Decode(doc.DocumentNode.InnerHtml);
            HtmlNodeCollection ContentList = doc.DocumentNode.SelectNodes("//a[@class='W_btn_b6']");
            var item = ContentList.FirstOrDefault();
            if (item == null) return null;
            else
            {
                var res = item.Attributes["action-data"];
                topicUrl = res.Value;
            }

            var ret = topicUrl.Substring(topicUrl.LastIndexOf(':')+1);
             return ret;
        }

        public static List<WeiBoContentItem> GetWeiBoTopicContentV2(string topicName, string targetName = "")
        {
            List<WeiBoContentItem> res = new List<WeiBoContentItem>();
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("https://s.weibo.com/weibo/" + topicName + "&Refer=weibo_weibo&xsort=time&realtimeweibo=1");
            doc.DocumentNode.InnerHtml= JavaScriptAnalyzer.Decode(doc.DocumentNode.InnerHtml);
            HtmlNodeCollection ContentList = doc.DocumentNode.SelectNodes("//div[@class='content clearfix']");
            //获取一个话题项
            ContentList.ToList().ForEach(p =>
            {
                var item = new WeiBoContentItem();
                //获取时间
                var timeItem = p.SelectNodes(".//a[@class='W_textb']");
                item.Time = Convert.ToDateTime(timeItem.FirstOrDefault()?.InnerText);
                var nickName = p.SelectNodes(".//a[@class='W_texta W_fb']");
                item.Author = nickName.FirstOrDefault()?.InnerText.Trim();
                var content = p.SelectNodes(".//p[@class='comment_txt']");
                item.ContentStr = content.FirstOrDefault()?.InnerText.Trim();
                var pic= p.SelectNodes(".//img[@action-type='feed_list_media_img']");
                item.Pic ="https:"+ pic.FirstOrDefault()?.Attributes.FirstOrDefault(c => c.Name=="src")?.Value.Replace("thumbnail","large");
                res.Add(item);
            });
            return res.Where(p => p.Author.Trim().Contains(targetName)).OrderByDescending(p => p.Time).ToList();
        }

        /// <summary>
        /// 获取微博话题内容列表(使用微博话题api),此接口返回内容详细，非常好用
        /// </summary>
        /// <param name="topicId">话题id</param>
        /// <param name="tragetName">指定发送者名称</param>
        /// <returns></returns>
        public static List<WeiBoContentItem> GetWeiBoTopicContentV3(string topicId, string targetName = "")
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
                else if (p.mblog.created_at.Contains("昨天"))
                {
                    var getNum = Convert.ToDateTime(p.mblog.created_at.Replace("昨天", "").Trim());
                    item.Time = getNum.AddDays(-1);
                }
                else if (p.mblog.created_at.Contains("前天"))
                {
                    var getNum = Convert.ToDateTime(p.mblog.created_at.Replace("前天", "").Trim());
                    item.Time = getNum.AddDays(-2);
                }
                else
                {
                    item.Time = Convert.ToDateTime(p.mblog.created_at);
                }

                theres.Add(item);
            });
            return theres.Where(p=>p.Author.Trim().Contains(targetName)).OrderByDescending(p=>p.Time).ToList();
        }


        /// <summary>
        /// 获取微博话题内容列表(使用微博话题api),此接口返回内容详细，非常好用
        /// </summary>
        /// <param name="topicId">话题名</param>
        /// <param name="tragetName">指定发送者名称</param>
        /// <returns></returns>
        public static List<WeiBoContentItem> GetWeiBoTopicContentV1(string topicName, string targetName = "")
        {
            var encode = System.Web.HttpUtility.UrlEncode(topicName);
            var res = JavaScriptAnalyzer.Decode(ToolClass.GetAPI($"https://m.weibo.cn/api/container/getIndex?type=all&queryVal={encode}&featurecode=20000320&luicode=10000011&lfid=106003type%3D1&title={encode}&containerid=100103type%3D61%26q%3D{encode}%26t%3D0"));
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
                    Author = p.mblog.user.screen_name,
                    ContentStr = htmlDocument.DocumentNode?.InnerText
                };
                if (p.mblog.created_at.Contains("分钟"))
                {
                    var getNum = Convert.ToInt32(p.mblog.created_at.Replace("分钟前", ""));
                    item.Time = DateTime.Now.AddMinutes(-getNum);
                }
                else if (p.mblog.created_at.Contains("小时"))
                {
                    var getNum = Convert.ToInt32(p.mblog.created_at.Replace("小时前", ""));
                    item.Time = DateTime.Now.AddHours(-getNum);
                }
                else if (p.mblog.created_at.Contains("昨天"))
                {
                    var getNum = Convert.ToDateTime(p.mblog.created_at.Replace("昨天", "").Trim());
                    item.Time = getNum.AddDays(-1);
                }
                else if (p.mblog.created_at.Contains("前天"))
                {
                    var getNum = Convert.ToDateTime(p.mblog.created_at.Replace("前天", "").Trim());
                    item.Time = getNum.AddDays(-2);
                }
                else
                {
                    item.Time = Convert.ToDateTime(p.mblog.created_at);
                }

                theres.Add(item);
            });
            return theres.Where(p => p.Author.Trim().Contains(targetName)).OrderByDescending(p => p.Time).ToList();
        }
    }
}
