﻿using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using ARR.API.App_Start;
using ARR.API.Infrastructure;
using ARR.API.Models;

using Autofac;
using Autofac.Integration.WebApi;

using Thinktecture.IdentityModel.Http.Cors.IIS;

namespace ARR.API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.AddProfile<IndexMappingProfile>();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            CorsConfig.RegisterCors(UrlBasedCorsConfiguration.Configuration);

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Build the container.
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}