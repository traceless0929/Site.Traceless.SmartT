using AutoMapper;
using Site.Traceless.SmartT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Traceless.SmartT
{
    /// <summary>
    /// 设置Mapper 映射关系（Model之间的）
    /// </summary>
    public class MapperConfig
    {
        /// <summary>
        /// 主要执行方法 
        /// </summary>
        public static void RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<TModel.FuncItem,TConfig>();
            });

            MapperUtil.Config(config.CreateMapper());
        }
    }

    public class MapperUtil
    {
        public static void Config(IMapper mapper)
        {
            Mapper = mapper;
        }
        public static IMapper Mapper { get; private set; }

        public static TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

    }
}
