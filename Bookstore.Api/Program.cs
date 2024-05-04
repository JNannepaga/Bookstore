// <copyright file="Program.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using OpenTelemetry.Exporter;
    using OpenTelemetry.Logs;
    using OpenTelemetry.Resources;

    /// <summary>
    /// Program that initiates the Bookstore App.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information)
                           .AddOpenTelemetry(options =>
                           {
                               options.IncludeFormattedMessage = true;
                               options.IncludeScopes = true;
                               options.ParseStateValues = true;
                               options.AddOtlpExporter(opt =>
                               {
                                   opt.Protocol = OtlpExportProtocol.Grpc;
                                   opt.Endpoint = new Uri("http://localhost:4317");
                               })
                                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName: "OTEL-Sample-POC"));
                           });
                                
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration(appConfig =>
                {
                    appConfig.AddJsonFile($"appsettings.json", false, true);
                    appConfig.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true);
                });
    }
}
