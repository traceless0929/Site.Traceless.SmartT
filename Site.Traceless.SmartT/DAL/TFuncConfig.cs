using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Site.Traceless.SmartT.DAL
{
    [Table("TFuncConfig")]
    public class TFuncConfig
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FuncName { get; set; }

        public bool IsOpen { get; set; }
    }
}
