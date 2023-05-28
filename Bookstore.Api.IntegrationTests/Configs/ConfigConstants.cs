namespace Bookstore.Api.IntegrationTests.Configs
{
    public static class ConfigConstants
    {
        public const string ASPNETCORE_APP_RUNNING_ENV = "ASPNETCORE_APP_RUNNING_ENV";
        public const string APP_SETTINGS_LOCAL = "appsettings.Tests.json";
        public const string APP_SETTINGS_DOCKER = "appsettings.Tests_Docker.json";
        public const string APP_SETTINGS_DOCKER_COMPOSE = "appsettings.Tests_DockerCompose.json";
        public const string ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER = "docker";
        public const string ASPNETCORE_APP_RUNNING_ENV_VALUE_DOCKER_COMPOSE = "dockercompose";
    }
}
