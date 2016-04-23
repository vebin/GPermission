using ECommon.Components;
using ECommon.Configurations;
using ECommon.Logging;
using ENode.Configurations;
using GPermission.Common;
using System;
using System.Reflection;
using ECommonConfiguration = ECommon.Configurations.Configuration;
namespace GPermission.ProcessorHost
{
    public class Bootstrap
    {
        private  ILogger _logger;
        private  ECommonConfiguration _ecommonConfiguration;
        private  ENodeConfiguration _enodeConfiguration;

        public  void Initialize()
        {
            InitializeECommon();
            try
            {
                InitializeENode();
            }
            catch (Exception ex)
            {
                _logger.Error("Initialize ENode failed.", ex);
                throw;
            }
        }
        public  void Start()
        {
            try
            {
                _enodeConfiguration.StartEQueue();
            }
            catch (Exception ex)
            {
                _logger.Error("EQueue start failed.", ex);
                throw;
            }
        }
        public  void Stop()
        {
            try
            {
                _enodeConfiguration.ShutdownEQueue();
            }
            catch (Exception ex)
            {
                _logger.Error("EQueue stop failed.", ex);
                throw;
            }
        }

        private  void InitializeECommon()
        {
            _ecommonConfiguration = ECommonConfiguration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet()
                .RegisterUnhandledExceptionHandler();
            _logger = ObjectContainer.Resolve<ILoggerFactory>().Create(typeof(Bootstrap).FullName);
            _logger.Info("ECommon initialized.");
        }

        private  void InitializeENode()
        {
            ConfigSettings.Initialize();

            var assemblies = new[]
            {
                Assembly.Load("GPermission.Common"),
                Assembly.Load("GPermission.Domain"),
                Assembly.Load("GPermission.Commands"),
                Assembly.Load("GPermission.CommandHandlers"),
                //Assembly.Load("Campus.MessagePublishers"),
                Assembly.Load("GPermission.Denormalizers"),
                Assembly.Load("GPermission.Repositories.Dapper"),
                //Assembly.Load("Campus.ProcessManagers"),
                //Assembly.Load("Campus.Messages"),
                Assembly.GetExecutingAssembly()
            };
            var setting = new ConfigurationSetting
            {
                DefaultDBConfigurationSetting = new DefaultDBConfigurationSetting(ConfigSettings.ENodeConnectionString)
            };

            _enodeConfiguration = _ecommonConfiguration
                .CreateENode(setting)
                .RegisterENodeComponents()
                .RegisterBusinessComponents(assemblies)
                .UseSqlServerLockService()
                .UseSqlServerCommandStore()
                .UseSqlServerEventStore()
                .UseEQueue()
                .InitializeBusinessAssemblies(assemblies);

            #region 锁

            //  ObjectContainer.Resolve<ILockService>().AddLockKey(typeof(RegionIndex).Name);

            #endregion

            _logger.Info("ENode initialized.");
        }
    }
}
