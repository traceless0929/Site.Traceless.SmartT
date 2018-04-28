using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TModel
{

    public class ConfigModel
    {
        /// <summary>
        /// 机器人名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主人QQ
        /// </summary>
        public string MasterQQ { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public string MenuStr { get; set; }
        /// <summary>
        /// 私聊菜单
        /// </summary>
        public string PrivateMenuStr { get; set; }
        /// <summary>
        /// 功能表
        /// </summary>
        public List<FuncItem> FunList { get; set; } = new List<FuncItem>();

        /// <summary>
        /// 指定功能是否开启
        /// </summary>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public bool IsFuncOpen(string funcName)
        {
            return FunList.Count(p => p.FuncName == funcName&&p.IsOpen==true)>0?true:false;
        }
    }

    public class FuncItem
    {
        public uint Id { get; set; }
        public int ParentId { get; set; }
        public string FuncName { get; set; } 
        public bool IsOpen { get; set; } 
    }

}
