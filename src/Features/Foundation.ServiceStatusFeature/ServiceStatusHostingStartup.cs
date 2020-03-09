using Foundation.ServiceStatusFeature;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ServiceStatusHostingStartup))]
namespace Foundation.ServiceStatusFeature
{
    public class ServiceStatusHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(svc => { svc.AddServiceStatusFeature(); });
        }
    }
}