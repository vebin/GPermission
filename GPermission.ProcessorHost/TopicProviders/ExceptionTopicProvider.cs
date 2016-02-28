using ECommon.Components;
using ENode.EQueue;
using ENode.Infrastructure;
using GPermission.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.ProcessorHost.TopicProviders
{
    [Component]
    public class ExceptionTopicProvider : AbstractTopicProvider<IPublishableException>
    {
        public override string GetTopic(IPublishableException exception)
        {
            return Topics.GPermissionExceptionTopic;
        }
    }
}
