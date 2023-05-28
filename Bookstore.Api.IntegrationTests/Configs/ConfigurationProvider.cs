using Microsoft.Extensions.Configuration;
using System;

namespace Bookstore.Api.IntegrationTests.Configs
{
    public static class ConfigurationProvider
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationProvider()
        {
            var runEnv = Environment.GetEnvironmentVariable(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV);
            var appsettings = runEnv.IsRunningInDocker()
                ? ConfigConstants.APP_SETTINGS_DOCKER
                : runEnv.IsRunningInDockerCompose()
                ? ConfigConstants.APP_SETTINGS_DOCKER_COMPOSE
                : ConfigConstants.APP_SETTINGS_LOCAL;

            Configuration = new ConfigurationBuilder()
                .AddJsonFile(appsettings)
                .Build();
        }

        private static bool IsRunningInDocker(this string runEnv) =>
            !string.IsNullOrEmpty(runEnv) && runEnv.Equals(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER, StringComparison.OrdinalIgnoreCase);
        private static bool IsRunningInDockerCompose(this string runEnv) =>
            !string.IsNullOrEmpty(runEnv) && runEnv.Equals(ConfigConstants.ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER_COMPOSE, StringComparison.OrdinalIgnoreCase);
    }
}
