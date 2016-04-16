using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>设置模块叶子节点状态事件
    /// </summary>
    public class ModuleLeafSetted : DomainEvent<string>
    {
        public int IsLeaf { get; private set; }

        public ModuleLeafSetted()
        {
        }

        public ModuleLeafSetted(int isLeaf) 
        {
            IsLeaf = isLeaf;
        }
    }
}
