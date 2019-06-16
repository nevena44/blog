using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Email;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.Commands.PostCommand;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.Commands.UserCommand;
using Blog.Application.Interfaces;
using Blog.EfCommands.HashtagEfCommand;
using Blog.EfCommands.PostEfCommand;
using Blog.EfCommands.RoleEfCommand;
using Blog.EfCommands.UserEfCommand;
using Blog.EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blog.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<BlogContext>();

            services.AddTransient<IGetPostCommand, EfGetPostCommand>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IGetOnePostCommand, EfGetOnePostCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();

            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<IGetOneRoleCommand, EfGetOneRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();

            services.AddTransient<IGetHashtagCommand, EfGetHashtagCommand>();
            services.AddTransient<ICreateHashtagCommand, EfCreateHashtagCommand>();
            services.AddTransient<IGetOneHashtagCommand, EfGetOneHashtagCommand>();
            services.AddTransient<IEditHashtagCommand, EfEditHashtagCommand>();
            services.AddTransient<IDeleteHashtagCommand, EfDeleteHashtagCommand>();

            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IGetOneUserCommand, EfGetOneUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
