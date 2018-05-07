using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Traceless.Api.Services;
using Traceless.Api.Services.Interface;

namespace Traceless.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver
                    = new Newtonsoft.Json.Serialization.DefaultContractResolver());//JSON首字母小写解决

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SmartT API",
                    Description="这是一个小T的API文档，就说那么多了，反正就我一个人用。啥？想聊聊？看下面好么宝贝。",
                    Contact=new Contact
                    {
                        Email="traceless0929@outlook.com",
                        Name="Traceless",
                        Url= "https://traceless.site/"
                    },
                    TermsOfService = "https://traceless.site/index.php/archives/62/"
                });

                //Determine base path for the application.  
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(basePath, "SmartT.Api.xml");
                options.IncludeXmlComments(xmlPath);
            });

            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IStasticService, StasticService>();
            //这里需要设置一下数据库链接，不然Linq2db连不上数据库
            LinqToDB.Data.DataConnection.DefaultSettings = new MySettings();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartT API V1");
            });

        }
    }
}
