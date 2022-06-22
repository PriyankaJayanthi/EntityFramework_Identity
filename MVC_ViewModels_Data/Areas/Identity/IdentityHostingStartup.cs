using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_ViewModels_Data.Data;
using MVC_ViewModels_Data.Models;

[assembly: HostingStartup(typeof(MVC_ViewModels_Data.Areas.Identity.IdentityHostingStartup))]
namespace MVC_ViewModels_Data.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}