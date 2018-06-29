using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools.Model
{
    public class WeiBoDirectContentItem
    {

        public class WeiBoDirectRes
        {
            public int ok { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Cardlistinfo cardlistInfo { get; set; }
            public Card[] cards { get; set; }
            public int showAppTips { get; set; }
            public string scheme { get; set; }
        }

        public class Cardlistinfo
        {
            public string containerid { get; set; }
            public int v_p { get; set; }
            public int show_style { get; set; }
            public int total { get; set; }
            public int page { get; set; }
        }

        public class Card
        {
            public int card_type { get; set; }
            public string itemid { get; set; }
            public string scheme { get; set; }
            public Mblog mblog { get; set; }
            public int show_type { get; set; }
        }

        public class Mblog
        {
            public string created_at { get; set; }
            public string id { get; set; }
            public string idstr { get; set; }
            public string mid { get; set; }
            public bool can_edit { get; set; }
            public string text { get; set; }
            public string source { get; set; }
            public bool favorited { get; set; }
            public bool is_paid { get; set; }
            public int mblog_vip_type { get; set; }
            public User user { get; set; }
            public long pid { get; set; }
            public Retweeted_Status retweeted_status { get; set; }
            public int reposts_count { get; set; }
            public int comments_count { get; set; }
            public int attitudes_count { get; set; }
            public int pending_approval_count { get; set; }
            public bool isLongText { get; set; }
            public int hide_flag { get; set; }
            public Visible1 visible { get; set; }
            public int more_info_type { get; set; }
            public int content_auth { get; set; }
            public Edit_Config1 edit_config { get; set; }
            public int mblogtype { get; set; }
            public int isTop { get; set; }
            public int weibo_position { get; set; }
            public string obj_ext { get; set; }
            public string raw_text { get; set; }
            public string bid { get; set; }
            public Title title { get; set; }
            public int textLength { get; set; }
            public string thumbnail_pic { get; set; }
            public string bmiddle_pic { get; set; }
            public string original_pic { get; set; }
            public string topic_id { get; set; }
            public bool sync_mblog { get; set; }
            public bool is_imported_topic { get; set; }
            public Page_Info1 page_info { get; set; }
            public Product_Struct[] product_struct { get; set; }
            public Pic1[] pics { get; set; }
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

        public class Retweeted_Status
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
            public bool is_paid { get; set; }
            public int mblog_vip_type { get; set; }
            public User1 user { get; set; }
            public int reposts_count { get; set; }
            public int comments_count { get; set; }
            public int attitudes_count { get; set; }
            public int pending_approval_count { get; set; }
            public bool isLongText { get; set; }
            public int hide_flag { get; set; }
            public Visible visible { get; set; }
            public int more_info_type { get; set; }
            public int content_auth { get; set; }
            public Edit_Config edit_config { get; set; }
            public int weibo_position { get; set; }
            public Page_Info page_info { get; set; }
            public int retweeted { get; set; }
            public string bid { get; set; }
            public int expire_time { get; set; }
            public string thumbnail_pic { get; set; }
            public string bmiddle_pic { get; set; }
            public string original_pic { get; set; }
            public Pic[] pics { get; set; }
            public string topic_id { get; set; }
            public bool sync_mblog { get; set; }
            public bool is_imported_topic { get; set; }
            public string cardid { get; set; }
            public string picStatus { get; set; }
        }

        public class User1
        {
            public long id { get; set; }
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
            public Badge1 badge { get; set; }
        }

        public class Badge1
        {
            public int bind_taobao { get; set; }
            public int follow_whitelist_video { get; set; }
            public int user_name_certificate { get; set; }
            public int suishoupai_2018 { get; set; }
            public int super_star_2018 { get; set; }
            public int unread_pool { get; set; }
            public int unread_pool_ext { get; set; }
            public int dzwbqlx_2016 { get; set; }
            public int panda { get; set; }
            public int wenchuan_10th { get; set; }
        }

        public class Visible
        {
            public int type { get; set; }
            public int list_id { get; set; }
        }

        public class Edit_Config
        {
            public bool edited { get; set; }
        }

        public class Page_Info
        {
            public Page_Pic page_pic { get; set; }
            public string page_url { get; set; }
            public string page_title { get; set; }
            public string content1 { get; set; }
            public string content2 { get; set; }
            public string type { get; set; }
            public Media_Info media_info { get; set; }
            public string object_id { get; set; }
        }

        public class Page_Pic
        {
            public string url { get; set; }
        }

        public class Media_Info
        {
            public string stream_url { get; set; }
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

        public class Visible1
        {
            public int type { get; set; }
            public int list_id { get; set; }
        }

        public class Edit_Config1
        {
            public bool edited { get; set; }
        }

        public class Title
        {
            public string text { get; set; }
            public int base_color { get; set; }
        }

        public class Page_Info1
        {
            public Page_Pic1 page_pic { get; set; }
            public string page_url { get; set; }
            public string page_title { get; set; }
            public string content1 { get; set; }
            public string content2 { get; set; }
            public string type { get; set; }
            public string object_id { get; set; }
        }

        public class Page_Pic1
        {
            public string url { get; set; }
        }

        public class Product_Struct
        {
            public string url { get; set; }
            public string name { get; set; }
            public string img { get; set; }
            public string page_id { get; set; }
            public Actionlog actionlog { get; set; }
            public Button[] buttons { get; set; }
        }

        public class Actionlog
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

        public class Button
        {
            public string name { get; set; }
            public string pic { get; set; }
            public string type { get; set; }
            public Params _params { get; set; }
            public int sub_type { get; set; }
            public Actionlog1 actionlog { get; set; }
        }

        public class Params
        {
            public string uid { get; set; }
            public string scheme { get; set; }
            public string type { get; set; }
        }

        public class Actionlog1
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

        public class Pic1
        {
            public string pid { get; set; }
            public string url { get; set; }
            public string size { get; set; }
            public Geo2 geo { get; set; }
            public Large1 large { get; set; }
        }

        public class Geo2
        {
            public int width { get; set; }
            public int height { get; set; }
            public bool croped { get; set; }
        }

        public class Large1
        {
            public string size { get; set; }
            public string url { get; set; }
            public Geo3 geo { get; set; }
        }

        public class Geo3
        {
            public string width { get; set; }
            public string height { get; set; }
            public bool croped { get; set; }
        }

    }
}
