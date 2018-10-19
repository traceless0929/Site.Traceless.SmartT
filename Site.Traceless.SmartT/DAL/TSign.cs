using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Site.Traceless.SmartT.DAL
{
    [Table("T_Sign")]
    public class TSign
    {
        [Key]
        public int Id { get; set; }
        public string Pid { get; set; }
        public string Gid { get; set; }

        public DateTime LastSign { get; set; }

        public string SignGid { get; set; }
    }
}
