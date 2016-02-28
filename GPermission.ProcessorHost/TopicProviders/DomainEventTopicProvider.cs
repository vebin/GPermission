using ECommon.Components;
using ENode.EQueue;
using ENode.Eventing;
using GPermission.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.ProcessorHost.TopicProviders
{
    [Component]
    public class DomainEventTopicProvider : AbstractTopicProvider<IDomainEvent>
    {
        public override string GetTopic(IDomainEvent evnt)
        {
            return Topics.GPermissionDomainEventTopic;
        }
    }
}
