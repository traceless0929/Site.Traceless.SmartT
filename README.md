# Site.Traceless.SmartT
剑三小T重制版

光荣地使用 [Newbe.Mahua.Framework](https://github.com/Newbe36524/Newbe.Mahua.Framework) 麻花疼！全球最装逼的QQ机器人C#SDK！没有之一！ 


# Traceless.Api
这个神奇的WEBAPI项目使用了linq2db.core 其中有一个帮助类,他是这样的
```C#
public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders
        {
            get { yield break; }
        }

        public string DefaultConfiguration => "Mysql";
        public string DefaultDataProvider => "MySql";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "TDatabase",
                        ProviderName = "MySql",
                        ConnectionString = @"Server=;Port=;Database=;Uid=;Pwd=;charset=;"
                    };
            }
        }
    }
```

# Traceless.TExtension.Tools

小T工具类，进行网页抓取、字符串处理、CQ码组合等各种杂七杂八的方法，其实很多方法应该放到Traceless.Util里，但是因为这里的方法都是老版小T的方法，所以懒得移...

# Traceless.Util 

通用工具类，小T无关，任何代码中都可能使用到的方法（Traceless.TExtension.Tools 中很多通用方法其实可以移过来，可是，有点懒）
