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
    public class ApplicationMessageTopicProvider : AbstractTopicProvider<IApplicationMessage>
    {
        public override string GetTopic(IApplicationMessage applicationMessage)
        {
            return Topics.GPermissionApplicationMessageTopic;
        }
    }
}
