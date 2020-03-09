using Microsoft.AspNetCore.Hosting;

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