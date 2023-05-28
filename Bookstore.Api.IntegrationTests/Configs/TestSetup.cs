using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testcontainers.MongoDb;
using Xunit;

namespace Bookstore.Api.IntegrationTests.Configs
{
    [Binding]
    public class TestSetup
    {
        private static MongoDbContainer _dbTestcontainer;

        static TestSetup()
        {
            if (IsRunningInLocal())
            {
                _dbTestcontainer = new MongoDbBuilder()
                   .WithImage("mongo:latest")
                   .WithEnvironment(new Dictionary<string, string>
                       {
                            { "MONGO_INITDB_ROOT_USERNAME", "root" },
                            { "MONGO_INITDB_ROOT_PASSWORD", "example" }
                       })
                   .WithUsername("root")
                   .WithPassword("example")
                   .WithPortBinding(27017, 27017)
                   .Build();
            }
        }

        [AfterTestRun]
        public static async Task DisposeAsync()
        {
            if (_dbTestcontainer != null)
            {
                await _dbTestcontainer.StopAsync();
                await _dbTestcontainer.DisposeAsync();
            }
        }

        [BeforeTestRun]
        public static async Task InitializeAsync()
        {
            if (_dbTestcontainer != null)
            {
                await _dbTestcontainer.StartAsync();
            }
        }

        private static bool IsRunningInLocal()
        {
            string isRunningInDocker = Environment.GetEnvironmentVariable(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV);
            return string.IsNullOrEmpty(isRunningInDocker) ||
                !(isRunningInDocker.Equals(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER, StringComparison.OrdinalIgnoreCase)
                || isRunningInDocker.Equals(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER_COMPOSE, StringComparison.OrdinalIgnoreCase));
        }
    }
}
