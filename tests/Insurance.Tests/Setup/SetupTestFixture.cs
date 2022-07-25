using Insurance.Api.Controllers;
using Insurance.Common;
using Insurance.Domain;
using Insurance.Manager;
using Insurance.Operations;
using Insurance.Repository;
using Insurance.Service;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;

namespace Insurance.Tests
{
    /// <summary>
    /// This class contains all the dependancies the test classes might need; which is dependency injected.
    /// </summary>
    public class SetupTestFixture
    {
        /// <summary>
        /// Access the ServiceProvider to get any DI class/object
        /// </summary>
        public ServiceProvider ServiceProvider { get; private set; }

        public SetupTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<Common.ILogger, SerilogLogger>();

            #region Product DI
            serviceCollection.AddTransient<IProductTypeService, ProductTypeServiceMock>();
            serviceCollection.AddTransient<IProductService, ProductServiceMock>();
            serviceCollection.AddTransient<IProductInsuranceService, ProductInsuranceService>();

            serviceCollection.AddTransient<IBasicInsuranceOperation, BasicInsuranceOperation>();
            serviceCollection.AddTransient<IExtraInsuranceOperation, ExtraInsuranceOperation>();

            serviceCollection.AddTransient<IProductInsuranceManager, ProductInsuranceManager>();
            #endregion

            #region Order DI
            serviceCollection.AddTransient<IOrderInsuranceService, OrderInsuranceService>();

            serviceCollection.AddTransient<IOrderBasicOperation, OrderBasicOperation>();
            serviceCollection.AddTransient<ICameraOrderInsuranceOperation, CameraOrderInsuranceOperation>();

            serviceCollection.AddTransient<IOrderInsuranceManager, OrderInsuranceManager>();
            #endregion

            #region SurchargeRate DI
            serviceCollection.AddTransient<ISurchargeRateService, SurchargeRateService>();
            serviceCollection.AddTransient<ISurchargeRateManager, SurchargeRateManager>();

            serviceCollection.AddTransient<ISurchargeRateRepository, SurchargeRateRepository>();
            #endregion

            serviceCollection.AddTransient<ProductInsuranceController, ProductInsuranceController>();
            serviceCollection.AddTransient<OrderInsuranceController, OrderInsuranceController>();
            serviceCollection.AddTransient<SurchargeRateController, SurchargeRateController>();

            //logger creation
            var projectDirctoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var insuranceLoggerFilePath = Path.Combine(projectDirctoryPath, "logs", "InsuranceLogger_.log");
            Log.Logger = new LoggerConfiguration().WriteTo.File(insuranceLoggerFilePath, rollingInterval: RollingInterval.Day).CreateLogger();

            serviceCollection.AddSingleton(typeof(Serilog.ILogger), Log.Logger);
            
            //building DI service provider
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
