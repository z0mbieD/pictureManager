using System;
using System.Reflection;
using Abp.Dependency;
using Abp.Modules;
using Abp.Startup;
using Abp.Startup.Application;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Abp.WebApi.Startup;

namespace PictureManager
{
    public class PictureManagerWebApiModule : AbpModule
    {
        public override Type[] GetDependedModules()
        {
            return new[]
                   {
                       typeof(AbpApplicationModule),
                       typeof(AbpWebApiModule),
                       typeof(PictureManagerApplicationModule)
                   };
        }

        public override void Initialize(IAbpInitializationContext initializationContext)
        {
            base.Initialize(initializationContext);
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .For<IPictureAppService>("picturemanager/picture")
                .Build();

            DynamicApiControllerBuilder
                .For<IUserAppService>("picturemanager/user")
                .Build();

            DynamicApiControllerBuilder
                .For<ICommentAppService>("picturemanager/comment")
                .Build();
        }
    }
}
