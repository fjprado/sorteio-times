using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SorterioDeTimesNew
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }

        

       
    }
}