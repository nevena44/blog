using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Blog.API.Email;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.Commands.PostCommand;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.Commands.UserCommand;
using Blog.Application.Helpers;
using Blog.Application.Interfaces;
using Blog.EfCommands;
using Blog.EfCommands.CommentCommand;
using Blog.EfCommands.HashtagEfCommand;
using Blog.EfCommands.PostEfCommand;
using Blog.EfCommands.RoleEfCommand;
using Blog.EfCommands.UserEfCommand;
using Blog.EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

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
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

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
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILoginCommand, EFLoginCommand>();

            services.AddTransient<IGetCommentCommand, EfGetCommentCommand>();
            services.AddTransient<IGetOneCommentCommand, EfGetOneCommentCommand>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IEditCommentCommand, EfEditCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

            services.AddTransient<ICreateImageCommand, EfCreatePictureCommand>();
               
            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

               services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encription(key);
            services.AddSingleton(enc);

            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encription>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });

        }
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
