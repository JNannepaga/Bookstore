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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging(logging =>
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
                                       opt.Endpoint = new Uri("http://otel-collector:4317"); // DNS name resolution.
                                       opt.ExportProcessorType = OpenTelemetry.ExportProcessorType.Batch;
                                   })
                                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName: "OTEL-Sample-POC"));
                               });

                    })
                    .ConfigureAppConfiguration(appConfig =>
                    {
                        appConfig.AddJsonFile($"appsettings.json", false, true);
                        appConfig.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true);
                    }).UseStartup<Startup>();
                });
    }
}
