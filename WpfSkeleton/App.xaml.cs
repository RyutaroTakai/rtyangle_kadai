using Microsoft.Extensions.Configuration;
using Models;
using Models.DB.Context;
using Models.Services;
using Prism.Ioc;
using System;
using System.IO;
using System.Windows;
using WpfSkeleton.Views;

namespace WpfSkeleton
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                // todo 補足されない例外が発生した場合の処理を書く
            };
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(path: "appsettings.json");
#if DEBUG
            builder.AddJsonFile("appsettings.debug.json");
#elif RELEASE
            builder.AddJsonFile("appsettings.release.json");
#endif
            var configuration = builder.Build();

            var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            var logger = factory.CreateLogger("");

            containerRegistry
                .RegisterInstance(configuration.Get<Settings>())
                .RegisterInstance(logger)
                .Register<DbContextBase, SQLServerContext>()
                .Register<ICalculation, Calculation>();
        }
    }
}