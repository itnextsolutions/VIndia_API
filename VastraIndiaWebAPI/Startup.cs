using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using VastraIndiaWebAPI.Models;

namespace VastraIndiaWebAPI
{
    //public class Startup
    //{
    //    public void Configure(IApplicationBuilder app)
    //    {
    //        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    //    }
    //}


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.      
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<CoreDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Database"))); //Add       
        //    services.AddControllers();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
