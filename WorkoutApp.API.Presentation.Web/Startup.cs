using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WorkoutApp.API.Application.Mapping;
using WorkoutApp.API.Application.Queries.Workout.GetWorkout;
using WorkoutApp.API.Presentation.Web.Models.Response;

namespace WorkoutApp.API.Presentation.Web
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:8080")
                        .WithHeaders("Content-Type"));
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowOrigin"));
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(WorkoutProfile)));
            services.AddMediatR(Assembly.GetAssembly(typeof(GetWorkoutRequest)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.UseCors();
            app.UseExceptionHandler(ExceptionHandler);
        }

        private void ExceptionHandler(IApplicationBuilder app)
        {
            app.Run(ctx =>
            {
                return Task.Run(async () =>
                {
                    ctx.Response.StatusCode = 500;
                    ctx.Response.ContentType = "application/json";
                    var exHandlerPathFeature = ctx.Features.Get<IExceptionHandlerPathFeature>();

                    var exception = exHandlerPathFeature.Error;
                    var uri = ctx.Request.Path;

                    //if (exception != null && exception is ItineraryAppHttpStatusCodeException)
                    //{
                    //    ctx.Response.StatusCode = (int)(exception as ItineraryAppHttpStatusCodeException).Code;
                    //}

                    //var logger = app.ApplicationServices.GetService<ILogger>();
                    //logger.Error(exception, "Error occured when processing request {uri}", uri);

                    var errorResponse = new ErrorResponse
                    {
                        Error = exception.Message,
                    };

                    if (exception.InnerException != null)
                    {
                        errorResponse.SubErrors.Add(exception.InnerException.Message);
                    }

                    //if (exception is RequestValidationFailedException)
                    //{
                    //    errorResponse.SubErrors.AddRange(
                    //        (exception as RequestValidationFailedException).Failures.Select(f => f.ErrorMessage));
                    //}

                    await ctx.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                });
            });
        }
    }
}
