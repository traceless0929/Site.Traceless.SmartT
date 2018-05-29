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

    public class WeiBoTopicRes
    {

        public int ok { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public Pageinfo pageInfo { get; set; }
            public Card[] cards { get; set; }
            public int showAppTips { get; set; }
            public string scheme { get; set; }
        }

        public class Pageinfo
        {
            public int page_size { get; set; }
            public string v_p { get; set; }
            public string containerid { get; set; }
            public string page_type_name { get; set; }
            public string title_top { get; set; }
            public string title_icon { get; set; }
            public string nick { get; set; }
            public string page_title { get; set; }
            public string page_attr { get; set; }
            public string page_url { get; set; }
            public int display_arrow { get; set; }
            public string oid { get; set; }
            public int follow_relation { get; set; }
            public string page_view { get; set; }
            public string detail_desc { get; set; }
            public string adid { get; set; }
            public string desc_scheme { get; set; }
            public string background_scheme { get; set; }
            public string portrait { get; set; }
            public string portrait_sub_text { get; set; }
            public string[] desc_more { get; set; }
            public string desc { get; set; }
            public Cardlist_Head_Cards[] cardlist_head_cards { get; set; }
            public Toolbar_Menus[] toolbar_menus { get; set; }
            public int total { get; set; }
            public string since_id { get; set; }
            public int adhesive { get; set; }
            public int show_style { get; set; }
            public string huati_exposure { get; set; }
            public string page_type { get; set; }
            public int attitudes_count { get; set; }
            public int attitudes_status { get; set; }
            public Button[] buttons { get; set; }
        }

        public class Cardlist_Head_Cards
        {
            public int head_type { get; set; }
            public string head_type_name { get; set; }
            public bool show_menu { get; set; }
            public string menu_scheme { get; set; }
            public Channel_List[] channel_list { get; set; }
        }

        public class Channel_List
        {
            public string id { get; set; }
            public string name { get; set; }
            public string containerid { get; set; }
            public string scheme { get; set; }
            public int must_show { get; set; }
            public int default_add { get; set; }
            public Filter_Group_Info filter_group_info { get; set; }
            public Filter_Group[] filter_group { get; set; }
        }

        public class Filter_Group_Info
        {
            public string title { get; set; }
            public string icon { get; set; }
            public string icon_name { get; set; }
            public string icon_scheme { get; set; }
        }

        public class Filter_Group
        {
            public string name { get; set; }
            public string containerid { get; set; }
            public string scheme { get; set; }
            public string title { get; set; }
        }

        public class Toolbar_Menus
        {
            public string type { get; set; }
            public int sub_type { get; set; }
            public int show_loading { get; set; }
            public string name { get; set; }
            public Params _params { get; set; }
            public Actionlog1 actionlog { get; set; }
            public object scheme { get; set; }
            public string pic { get; set; }
        }

        public class Params
        {
            public string uid { get; set; }
            public string type { get; set; }
            public string scheme { get; set; }
            public Menu_List[] menu_list { get; set; }
        }

        public class Menu_List
        {
            public string type { get; set; }
            public string name { get; set; }
            public Params1 _params { get; set; }
            public Actionlog actionlog { get; set; }
            public string scheme { get; set; }
        }

        public class Params1
        {
            public string scheme { get; set; }
        }

        public class Actionlog
        {
            public int act_code { get; set; }
            public string ext { get; set; }
            public string fid { get; set; }
        }

        public class Actionlog1
        {
            public int act_code { get; set; }
            public string ext { get; set; }
            public string fid { get; set; }
        }

        public class Button
        {
            public string type { get; set; }
            public string sub_type { get; set; }
            public string name { get; set; }
            public Params2 _params { get; set; }
            public string scheme { get; set; }
        }

        public class Params2
        {
            public string id { get; set; }
            public string type { get; set; }
        }

        public class Card
        {
            public int card_type { get; set; }
            public string card_type_name { get; set; }
            public int is_asyn { get; set; }
            public string itemid { get; set; }
            public string async_api { get; set; }
            public string _appid { get; set; }
            public string _cur_filter { get; set; }
            public string title { get; set; }
            public int show_type { get; set; }
            public string buttontitle { get; set; }
            public string scheme { get; set; }
            public string[] hide_oids { get; set; }
            public Card_Group[] card_group { get; set; }
        }

        public class Card_Group
        {
            public int card_type { get; set; }
            public string itemid { get; set; }
            public int show_type { get; set; }
            public string scheme { get; set; }
            public Mblog mblog { get; set; }
        }

        public class Mblog
        {
            public string created_at { get; set; }
            public string id { get; set; }
            public string idstr { get; set; }
            public string mid { get; set; }
            public bool can_edit { get; set; }
            public string text { get; set; }
            public int textLength { get; set; }
            public string source { get; set; }
            public bool favorited { get; set; }
            public string thumbnail_pic { get; set; }
            public string bmiddle_pic { get; set; }
            public string original_pic { get; set; }
            public bool is_paid { get; set; }
            public int mblog_vip_type { get; set; }
            public User user { get; set; }
            public int reposts_count { get; set; }
            public int comments_count { get; set; }
            public int attitudes_count { get; set; }
            public int pending_approval_count { get; set; }
            public bool isLongText { get; set; }
            public Visible visible { get; set; }
            public string topic_id { get; set; }
            public bool sync_mblog { get; set; }
            public bool is_imported_topic { get; set; }
            public string rid { get; set; }
            public int more_info_type { get; set; }
            public int content_auth { get; set; }
            public int mblog_show_union_info { get; set; }
            public int is_controlled_by_server { get; set; }
            public string timestamp_text { get; set; }
            public int expire_after { get; set; }
            public int weibo_position { get; set; }
            public Page_Info page_info { get; set; }
            public Product_Struct[] product_struct { get; set; }
            public string bid { get; set; }
            public Pic[] pics { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string screen_name { get; set; }
            public string profile_image_url { get; set; }
            public string profile_url { get; set; }
            public int statuses_count { get; set; }
            public bool verified { get; set; }
            public int verified_type { get; set; }
            public int verified_type_ext { get; set; }
            public string verified_reason { get; set; }
            public bool close_blue_v { get; set; }
            public string description { get; set; }
            public string gender { get; set; }
            public int mbtype { get; set; }
            public int urank { get; set; }
            public int mbrank { get; set; }
            public bool follow_me { get; set; }
            public bool following { get; set; }
            public int followers_count { get; set; }
            public int follow_count { get; set; }
            public string cover_image_phone { get; set; }
            public string avatar_hd { get; set; }
            public bool like { get; set; }
            public bool like_me { get; set; }
            public Badge badge { get; set; }
        }

        public class Badge
        {
            public int dzwbqlx_2016 { get; set; }
            public int user_name_certificate { get; set; }
            public int suishoupai_2018 { get; set; }
            public int wenchuan_10th { get; set; }
        }

        public class Visible
        {
            public int type { get; set; }
            public int list_id { get; set; }
        }

        public class Page_Info
        {
            public Page_Pic page_pic { get; set; }
            public string page_url { get; set; }
            public string page_title { get; set; }
            public string content1 { get; set; }
            public string content2 { get; set; }
            public string type { get; set; }
            public string object_id { get; set; }
        }

        public class Page_Pic
        {
            public string url { get; set; }
        }

        public class Product_Struct
        {
            public string url { get; set; }
            public string name { get; set; }
            public string img { get; set; }
            public string page_id { get; set; }
            public Actionlog2 actionlog { get; set; }
            public Button1[] buttons { get; set; }
        }

        public class Actionlog2
        {
            public string act_code { get; set; }
            public int uid { get; set; }
            public long mid { get; set; }
            public string oid { get; set; }
            public string uicode { get; set; }
            public string cardid { get; set; }
            public string fid { get; set; }
            public string luicode { get; set; }
            public string lfid { get; set; }
            public string ext { get; set; }
            public string source { get; set; }
        }

        public class Button1
        {
            public int sub_type { get; set; }
            public Actionlog3 actionlog { get; set; }
        }

        public class Actionlog3
        {
            public int act_code { get; set; }
            public int uid { get; set; }
            public long mid { get; set; }
            public string oid { get; set; }
            public string uicode { get; set; }
            public string cardid { get; set; }
            public string fid { get; set; }
            public string luicode { get; set; }
            public string lfid { get; set; }
            public string ext { get; set; }
            public string source { get; set; }
        }

        public class Pic
        {
            public string pid { get; set; }
            public string url { get; set; }
            public string size { get; set; }
            public Geo geo { get; set; }
            public Large large { get; set; }
        }

        public class Geo
        {
            public int width { get; set; }
            public int height { get; set; }
            public bool croped { get; set; }
        }

        public class Large
        {
            public string size { get; set; }
            public string url { get; set; }
            public Geo1 geo { get; set; }
        }

        public class Geo1
        {
            public string width { get; set; }
            public string height { get; set; }
            public bool croped { get; set; }
        }

    }
}
