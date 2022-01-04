// See https://aka.ms/new-console-template for more information
using log4net;
using log4net.Config;
using log4net.Repository;
using MarsRover.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = new ConfigurationBuilder();

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<RoverService>();
        services.AddSingleton(factory => logRepository);
    })
    .Build();

var roverService = ActivatorUtilities.CreateInstance<RoverService>(host.Services);
roverService.Run();

