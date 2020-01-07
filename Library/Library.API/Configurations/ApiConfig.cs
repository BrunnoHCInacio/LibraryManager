using AutoMapper.Configuration;
using Library.API.Parameters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace Library.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfiguration(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods(DomainParameters.MethodGET,
                                         DomainParameters.MethodPOST,
                                         DomainParameters.MethodPUT,
                                         DomainParameters.MethodDELETE)
                            .AllowAnyOrigin()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });
            return services;
        }

        public static IApplicationBuilder UserMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
            return app;
        }
    }
}
