using ECommon.Socketing;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using EQueue.Clients.Producers;
using EQueue.Configurations;
using GPermission.Common;
using System.Net;

namespace GPermission.Admin.Extensions
{
    public static class ENodeExtensions
    {
        private static CommandService _commandService;

        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _commandService = new CommandService(new CommandResultProcessor(new IPEndPoint(ConfigSettings.CommandBindingPort, 9002)), new ProducerSetting
            {
                BrokerAddress = new IPEndPoint(ConfigSettings.BrokerAddress, ConfigSettings.BrokerProducerPort),
                BrokerAdminAddress = new IPEndPoint(ConfigSettings.BrokerAddress, ConfigSettings.BrokerAdminPort)
            });

            configuration.SetDefault<ICommandService, CommandService>(_commandService);

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandService.Start();
            return enodeConfiguration;
        }
    }
}