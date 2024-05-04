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
                   Title = "Wedding Wise",
                   Version = "v1.0",

                   Description = @"
<b>Title:</b> WeddingWise - Halls & Cars

<b>Description:</b> This API empowers a seamless wedding planning experience by facilitating online reservations for wedding halls and car rentals.

<b>Functionalities:</b>

<b>Clients:</b>
- Search and browse available wedding halls and car rentals.
- Make online reservations for halls and cars.
- Manage existing reservations (view, modify, cancel). 

<b>Agents:</b>
- Register via Employee and manage their profiles.
- Request to Add new wedding halls and car rentals to the platform.
- Manage listed halls and cars (availability, pricing, descriptions etc.).
- View client reservations for their listings.

<b>Authentication:</b>
- The API utilizes a JWT authentication system.
- Clients and agents need to register and obtain tokens for authorization.
",

                   TermsOfService = new Uri("https://example.com/terms"),
                   Contact = new OpenApiContact
                   {
                       Name = "Akram Injaileh",
                       Email = "akraminjaileh@gmail.com",
                       Url = new Uri("https://wa.me/+962787454867"),
                   },
                   License = new OpenApiLicense
                   {
                       Name = "WeddingWise LICX",
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
