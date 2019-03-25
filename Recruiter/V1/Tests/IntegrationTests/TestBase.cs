using System;
using System.Net.Http;
using guid_reactapp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CandidateModel.Models;
using Microsoft.AspNetCore.Builder;

namespace IntegrationTests
{
    
public class TestStartup : Startup
{
    public TestStartup(IConfiguration configuration) : base(configuration)
    {
    }
 
    public override void ConfigureDatabase(IServiceCollection services)
    {          
      services.AddDbContext<TableContext>(opt =>  opt.UseInMemoryDatabase("QandAList"));  
       // Register the database seeder
      services.AddTransient<DatabaseSeeder>();
    }

    public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
    
        base.Configure(app, env);
    
        // Now seed the database
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var seeder = serviceScope.ServiceProvider.GetService<DatabaseSeeder>();
            seeder.Seed();
        }
    }
}

    public class TestBase
    {
        protected HttpClient Client { get; private set; } 
        protected TestBase()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
    
            Client =  server.CreateClient();
        }

    }

    public class DatabaseSeeder
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly TableContext _context;
    
        public DatabaseSeeder(TableContext context)
        {
            _context = context;       
        }
    
        public void Seed()
        {
            var candidateContent=new MyCandidate();
            candidateContent.Id= "9999";
            candidateContent.ResourceRequisition= "Seed Manager";
            candidateContent.CandidateEmail= "Seed@example.com";
            candidateContent.Stages= 3;
            candidateContent.ResumeText="Seed Resume";
            candidateContent.ResumeUpload="";
            candidateContent.PanelDeadline=new DateTime(); 
            _context.MyCandidates.Add(candidateContent);
            _context.SaveChanges(); 
        }
    }
}
