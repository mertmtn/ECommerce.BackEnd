using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.MongoDb;
using ECommerce.Data.Concrete.MongoDb.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.OpenApi.Models; 

namespace ECommerce.API
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
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            
            //services.AddTransient<IProductService, ProductManager>();
            //services.AddTransient<ICategoryService, CategoryManager>();

            //services.AddTransient<ICategoryDal, MongoCategoryDal>();
            //services.AddTransient<IProductDal, MongoProductDal>();

            //services.AddTransient<IMongoDbContext, MongoDbContext>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce.API", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
