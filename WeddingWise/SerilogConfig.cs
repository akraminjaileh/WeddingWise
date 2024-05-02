using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WeddingWise
{
    public static class SerilogConfig
    {
        public static void AddSwaggerGenSerilog(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1.0", new OpenApiInfo
               {
                   Title = "Resturant Management API",
                   Version = "v1.0",

                   Description = "This API  as a restaurant management system, " +
                   "offering shared functions accessible to all users, known as shared functions, " +
                   "alongside individualized functionalities for each user, ensuring " +
                   "varied permissions among users.",

                   TermsOfService = new Uri("https://example.com/terms"),
                   Contact = new OpenApiContact
                   {
                       Name = "Akram Injaileh",
                       Email = "akraminjaileh@gmail.com",
                       Url = new Uri("https://wa.me/+962787454867"),
                   },
                   License = new OpenApiLicense
                   {
                       Name = "Resturant Management API LICX",
                       Url = new Uri("https://example.com/license"),
                   }
               });

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               c.IncludeXmlComments(xmlPath);


           });
        }
    }
}
