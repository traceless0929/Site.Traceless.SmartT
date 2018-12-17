using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceless.TExtension.Tools.Model
{
    public class OrderInfoModel
    {
        public int OrderCount { get; private set; } = 0;
        public string What { get; private set; } = "";
        public string Who { get; private set; } = "";
        public string How { get; private set; } = "";
        public string OriginStr { get; private set; }

        public OrderInfoModel(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            try
            {
                OriginStr = msg;
                string[] temp = msg.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length == 0)
                {
                    What = msg;
                    OrderCount = 0;
                }
                else if (temp.Length == 1)
                {
                    What = temp[0];
                    OrderCount = 1; ;
                }
                else if (temp.Length == 2)
                {
                    What = temp[0];
                    Who = temp[1];
                    OrderCount = 2;
                }
                else if (temp.Length > 2)
                {
                    What = temp[0];
                    Who = temp[1];
                    for (int i = 2; i < temp.Length; i++)
                        How += temp[i] + " ";
                    OrderCount = 3;
                }
            }
            catch (Exception ex)
            {
                OrderCount = 0;
                What = ex + "";
            }
        }
    }
}
