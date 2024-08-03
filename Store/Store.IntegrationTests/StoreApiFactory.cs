using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.IntegrationTests
{
    public class StoreApiFactory<TProgam> : WebApplicationFactory<TProgam>  where TProgam : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Tests");

            builder.ConfigureTestServices(services =>
            {
                var dbContextDescription = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StoreContext>));
                services.Remove(dbContextDescription);
            });

        }

    }
}
