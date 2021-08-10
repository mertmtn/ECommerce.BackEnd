using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ECommerce.Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.MongoDb;

namespace ECommerce.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {        
        protected override void Load(ContainerBuilder builder)
        {              
            builder.RegisterType<MongoProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<MongoCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<MongoCartItemDal>().As<ICartItemDal>().SingleInstance();
            builder.RegisterType<MongoCartDal>().As<ICartDal>().SingleInstance();

            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();
            builder.RegisterType<CartItemManager>().As<ICartItemService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            builder.RegisterType<MongoDbContext>().As<IMongoDbContext>().SingleInstance();
         
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}