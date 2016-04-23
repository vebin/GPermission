using ENode.Commanding;

namespace GPermission.Commands.AppSystems
{
    public class ChangeAppSystem:Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeAppSystem()
        {
            
        }

        public ChangeAppSystem(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
