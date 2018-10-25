using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using Site.Traceless.SmartT.Func;
using Traceless.TExtension.Tools;

namespace Site.Traceless.SmartT.CorP
{
    internal class ChoseApp : Approver
    {
        private readonly IMahuaApi _mahuaApi;
        public ChoseApp(IMahuaApi mahuaApi, Approver approver)
        {
            _mahuaApi = mahuaApi;
            this.SetSuccesser(approver);
        }
        public override void ProcessRequset(GroupMessageReceivedContext msg, AnalysisMsg nowModel)
        {
            if (Config.ConfigModel.IsFuncOpen("抽锦鲤"))
            {
                if (nowModel.What == "抽锦鲤")
                {
                    try
                    {
                        var data = ToolClass.GetIni(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            $"{msg.FromGroup}.ini"));
                        if (data == null)
                        {
                            _mahuaApi.SendGroupMessage(msg.FromGroup).At(msg.FromQq)
                                .Text($"群成员未导入，请联系管理员").Done();
                        }
                        else
                        {
                            var allMember = data.ToList();
                            var orderid = Guid.NewGuid().ToString("N");
                            _mahuaApi.SendGroupMessage(msg.FromGroup).At(msg.FromQq)
                                .Text($"5S后,开始从{allMember.Count()}人中抽取幸运锦鲤{nowModel.Who}!").Newline().Text($"锦鲤编号:{orderid}").Done();
                            System.Threading.Thread.Sleep(5000);
                            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"Boom!{orderid}号{nowModel.Who}的锦鲤为！").Newline()
                                .At(allMember[ToolClass.RandomGet(0, allMember.Count())]).Newline()
                                .Text("围殴他ヽ(●-`Д´-)ノ！").Done();
                        }

                    }
                    catch (Exception ex)
                    {
                        successor.ProcessRequset(msg, nowModel);
                    }
                    //var ident = _mahuaApi.GetGroupMemberInfo(msg.FromGroup, msg.FromQq);
                    //if (ident.Authority == GroupMemberAuthority.Leader || ident.Authority == GroupMemberAuthority.Manager || msg.FromQq == Config.ConfigModel.MasterQQ)
                    //{
                    //    try
                    //    {
                    //        var data = ToolClass.GetIni(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    //            $"{msg.FromGroup}.ini"));
                    //        if (data == null)
                    //        {
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).At(msg.FromQq)
                    //                .Text($"群成员未导入，请联系管理员").Done();
                    //        }
                    //        else
                    //        {
                    //            var allMember = data.ToList();
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).At(msg.FromQq)
                    //                .Text($"开始从{allMember.Count()}人中抽取幸运锦鲤!").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"5.....").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"4....").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"3...").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"2..").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"1.").Done();
                    //            System.Threading.Thread.Sleep(1000);
                    //            _mahuaApi.SendGroupMessage(msg.FromGroup).Text($"Boom!本次的锦鲤为！").Newline()
                    //                .At(allMember[ToolClass.RandomGet(0, allMember.Count())]).Newline()
                    //                .Text("围殴他ヽ(●-`Д´-)ノ！").Done();
                    //        }
                            
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        successor.ProcessRequset(msg, nowModel);
                    //    }
                        
                    //}

                }
            }
            successor.ProcessRequset(msg, nowModel);
        }

        public override void ProcessRequset(PrivateMessageFromFriendReceivedContext msg, AnalysisMsg nowModel)
        {
            successor.ProcessRequset(msg, nowModel);
        }
    }
}
