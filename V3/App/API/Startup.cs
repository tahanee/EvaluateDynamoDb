using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Amazon.DynamoDBv2;
using System;

namespace EvaluateRecruiterAPI
{

    public class Startup
    {
        private string hostDB ;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        { 
            Configuration = configuration;   
            hostDB = Configuration["db"];
           
        }

        public IConfiguration Configuration { get;set; }
        public virtual void ConfigureServices(IServiceCollection services)
        {
             ConfigureDatabase(services);
                services.AddCors();
                services.AddMvc();   
                   
                services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
                services.AddAWSService<IAmazonDynamoDB>();        

                Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
                Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
                Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {          
            if(hostDB != null &&  hostDB != string.Empty)
              services.AddDbContext<TableContext>(options =>options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            else
             services.AddDbContext<TableContext>(opt => opt.UseSqlite("Data Source=../DB/Recruiter.db"));
                               
        }
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();         
        }
    }
}
